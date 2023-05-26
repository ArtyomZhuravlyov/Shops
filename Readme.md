1. Проведена нормализация данных
2. update миграций происходит автоматически, поэтому дополнительно вызывать их не нужно.
3. В миграцию уже добавлено заполнение начальных данных.
4. Для запуска нужно установить ваше подключение DefaultConnection в appsettings.json.
5. Для запуска через студию необходимо выбрать 2 запускаемых проекта одновременно Shops.Server и Shops.Client через свойства решения.
6. Совсем не понял по какой харахтеристике строить гистограмму, поэтому построил просто по магазинам.
7. Для клиентской части использовался Blazor Server.
8. К сожалению, не успел сделать тесты и упаковать в докер.

Опубликованные файлы клиента и сервера https://cloud.mail.ru/public/sMwu/DKkP8i4JR
1. Для запуска серверной части необходимо отредактировать фаил appsettings.json. Установив правильное подключение к базе "DefaultConnection": "Server=localhost;Port=5432;Database=Shops;User Id=dduser;Password=dduser".
2. Запуск сервера производим через ввод в командной строке dotnet Shops.Server.dll --urls=http://localhost:5074/ (Порт здесь важен) в папке с проектом сервера.
3. Проверяем работу в браузере по адресу http://localhost:5074/api/shop - получаем все магазины.
4. Для запуска клиентсвой части вводим в командной строке dotnet Shops.Client.dll в папке с проектом клиента.
5. Проверяем работу клиентской части и сервера по адресу http://localhost:5000/
