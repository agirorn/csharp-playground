.PHONY: dev
dev:
	yardman \
		Makefile \
		'*.cs' \
		'**/*.cs' \
		'*.csproj' \
		'../**/*.csproj' \
		'make dev-exec'

.PHONY: dev-exec
dev-exec:
	clear
	# make clean
	make test

.PHONY: test
test:
	make test-unit

.PHONY: test-unit
test-unit:
	cd tests && dotnet test unit

.PHONY: test-integration
test-integration:
	cd tests && dotnet test integration

.PHONY: clean
clean:
	rm -rf test/unit/bin test/unit/obj  src/obj  src/obj
