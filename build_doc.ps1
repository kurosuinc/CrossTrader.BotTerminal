$cd = (Get-Location).Path
docker run --rm -v "$cd\doc:/out" -v "$cd\proto:/protos" pseudomuto/protoc-gen-doc --doc_opt=markdown,docs.md