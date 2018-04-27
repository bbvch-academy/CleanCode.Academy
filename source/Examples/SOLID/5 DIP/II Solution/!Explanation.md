# DIP

## Definition

Entities must depend on abstractions not on concretions. It states that the high
level module must not depend on the low level module, but they should depend
on abstractions.

## Violation Example

Let's have a look at the following class design.

```

    ,---------------.               ,------------.
    |Notification   |               |Email       |
    |---------------|-------------->|------------|
    |+Send()        |     `         |+SendMail() |
    `---------------'      |        `------------'
                           |        
                           |        ,-----------.
                           |        |SMS        |
                            `------>|-----------|
                                    |+SendSMS() |
                                    `-----------'

```

In this example we use a `Notification` class to send two types of messages:
email and SMS. The method `Send()` of the `Notification` class invokes the
`Send()` method of the two repsectiv message classes.

If we add a new message class or remove an existing one, we will be forced
to modify the Notification class as well. Furthermore the `Notificiation`
"knows" the concrete implementations of `EMail` and `SMS`.

How can we solve this issue?

## Possible Solution

A possible solution would be to introduce an interface `IMessage`. The
classes `Email` and `SMS` will implement this new interface and the
`Notification` does not need to depend on the concrete implementations but
on the new interface. Therefore the `Notification` class has no dependency
at the two concrete implementations, allowing us to move them even in to
another namespace.

```

    ,---------------.               ,--------------- .
    |Notification   |               |<< interface >> |
    |---------------|-------------->|IMessage        |
    |+Send()        |               |----------------|
    `---------------'               |+Send()         |
                                    `----------------'
                         _______________    A                  
                        | Implemenation |   |                  
                        |——————————————————————————————————————.
                        |           ,------´ `-------,         |
                        |           |                |         |
                        |    ,-----------.      ,-----------.  |
                        |    |Email      |      |SMS        |  |
                        |    `-----------'      `-----------'  |
                        |                                      |
                        `——————————————————————————————————————´
```