// ReSharper disable CheckNamespace

namespace CleanCode.Design.SolidSolution
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Newtonsoft.Json;

    /// <summary>
    /// Contains all available items.
    /// </summary>
    public class ItemCollection
    {
        /// <summary>
        /// The content of this string would usually be stored in a text file or in some kind of a database.
        /// However, for this exercise we take the items directly from this field variable.
        /// </summary>
        private const string ItemsAsJsonString = @"[
{id:'1',type:'book',title:'Clean Code',author:'Robert C. Martin',price:'29.90'},
{id:'2',type:'notebook',title:'A4 Notebook (Red)',price:'9.90',color:'Red'},
{id:'3',type:'notebook',title:'A4 Notebook (Blue)',price:'9.90',color:'Blue'},
{id:'4',type:'notebook',title:'A4 Notebook (Green)',price:'9.90',color:'Green'},
{id:'5',type:'notebook',title:'A4 Notebook (Yellow)',price:'9.90',color:'Yellow'},
{id:'6',type:'pen',title:'Pen (Red)',price:'4.90',color:'Red'},
{id:'7',type:'pen',title:'Pen (Blue)',price:'4.90',color:'Blue'},
{id:'8',type:'pen',title:'Pen (Green)',price:'4.90',color:'Green'},
]";

        private List<Item> allItems;

        public void Initialize()
        {
            this.allItems = DeserializeJson(ItemsAsJsonString);
        }

        public IReadOnlyList<Item> GetAllItems()
        {
            return this.allItems.ToArray();
        }

        public Pen GetPen(PenColor color)
        {
            // NOTE
            // This example shows, that abandoning the type property in the base class comes with some costs.
            // The select statement within the linq query is somewhat more complex than before.
            return this.allItems
                .First(item => item.IsA<Pen>() && item.As<Pen>().Color == color) as Pen;
        }

        public Book GetBook()
        {
            return this.allItems
                .First(item => item.IsA<Book>()) as Book;
        }

        public Notebook GetNotebook(NotebookColor color)
        {
            return this.allItems
                .First(item => item.IsA<Notebook>() && item.As<Notebook>().Color == color) as Notebook;
        }

        private static List<Item> DeserializeJson(string json)
        {
            var items = JsonConvert.DeserializeObject<List<ItemJsonDefinition>>(json);

            var result = new List<Item>();

            // get all types that implement the deserialization interface
            var interfaceType = typeof(ICanBeDeserializedFromJson);
            var myTypes = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => x.IsClass && interfaceType.IsAssignableFrom(x))
                .ToArray();

            var implementations = new List<ICanBeDeserializedFromJson>();
            foreach (var myType in myTypes)
            {
                var instance = (ICanBeDeserializedFromJson)Activator.CreateInstance(myType);
                implementations.Add(instance);
            }

            // deserialize the json string using the appropriate type
            foreach (var j in items)
            {
                var impl = implementations
                    .FirstOrDefault(x => x.TypeName == j.Type);

                if (impl == null)
                {
                    throw new InvalidOperationException(
                        $"No implementation found for deserializing the type: {j.Type}");
                }

                var item = impl.DeserializeFrom(j);
                result.Add(item);
            }

            return result;
        }
    }
}