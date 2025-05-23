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
	# clear
	line-cli
	make clean
	make test
	line-cli

.PHONY: test
test:
	make test-integration

.PHONY: test-integration
test-integration:
	cd tests && dotnet test integration

.PHONY: clean
clean:
	rm -rf test/unit/bin test/unit/obj  src/obj  src/obj
