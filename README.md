# OnionArchOrnegi

docker run --name redis-onion -p 6379:6379 -d redis  redis için docket terminal kodu.

docker run --name postgres-container   -e POSTGRES_USER=umut -e POSTGRES_PASSWORD=123456  -p 5432:5432   -d postgres  için docket terminal kodu.

dotnet ef migrations add ThirtMigration --startup-project ../OnionArchOrnegi.WebAPI --output-dir Migrations && dotnet ef database update --startup-project ../OnionArchOrnegi.WebAPI migration komutları

migration sonrası umut@gmail.com-123umut123 seed datası oluşur. sisteme login olunabilir.
