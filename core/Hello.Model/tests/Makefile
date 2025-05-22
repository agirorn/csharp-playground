.PHONY: dev
dev:
	yardman \
		Makefile \
		'../*.cs' \
		'../**/*.cs' \
		'../*.csproj' \
		'../../**.*.csproj' \
		'make dev-exec'

.PHONY: dev-exec
dev-exec:
	clear
	make test

.PHONY: test
test:
	make test-unit

.PHONY: test-unit
test-unit:
	dotnet test unit

.PHONY: test-integration
test-integration:
	dotnet test integration

