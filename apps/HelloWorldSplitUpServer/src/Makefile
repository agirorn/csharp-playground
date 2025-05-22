DB_USER=admin
DB_PASS=admin
DB_NAME=hello_dev
DB_HOST=localhost
PSQL=PGPASSWORD=$(DB_PASS) psql -U $(DB_USER) -d $(DB_NAME) -h $(DB_HOST)

.PHONY: start
start:
	dotnet run

.PHONY: migrate
migrate:
	$(PSQL) -f migrations/V1.0.0__Creata_tabls.sql

.PHONY: dev
dev:
	yardman \
		Makefile \
		'*.cs' \
		'**/*.cs' \
		'*.csproj' \
		'../**/*.csproj' \
		'!**/obj/**' \
		'clear; echo "file changed -> {{file}}" ; make dev-exec'

.PHONY: dev-exec
dev-exec:
	make start
