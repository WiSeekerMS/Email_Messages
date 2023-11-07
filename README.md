# Unity Email Messages - Unity Plugin

## :pencil: Documentation

To send messages via the SMTP protocol, you must create a password for the external application. This password is specified in the _Password_ field of the config file

### Configuration File Example:
```
Login: example@mail.ru
Password: 12345

Host: smtp.mail.ru
Port: 25
Timeout: 5000
EnableSSL: true

FromMailAddress: example@mail.ru
ToMailAddress: recipient@mail.ru
```

## :balance_scale: License

Usage is provided under the [MIT License](LICENSE).
