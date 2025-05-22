DB_USER=admin
DB_PASS=admin
DB_NAME=hello_dev
DB_HOST=localhost
PSQL=PGPASSWORD=$(DB_PASS) psql -U $(DB_USER) -d $(DB_NAME) -h $(DB_HOST)

.PHONY: start
start:
	dotnet start

.PHONY: migrate
migrate:
	$(PSQL) -f migrations/V1.0.0__Creata_tabls.sql
