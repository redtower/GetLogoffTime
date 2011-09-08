
get.exe: get.cs
	csc /out:get.exe get.cs

clean:
	@rm -f get.exe
