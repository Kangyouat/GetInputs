1.This application takes two inputs and a flag
	a. A directory that contains the files to be analyzed
	b. A path for the output file (including file name and extension)
	c. A flag to determine whether or not to include subdirectories contained (and all subsequently embedded subdirectories) within the input directory([a.] above)
2. It will processes each of the files in the directory (if the flag is present, subdirectories will be processed as well)
3. There is a file signature to determine if it is a PDF or JPG
	a. JPG files have 0xKTLM16
	b. PDF files have 0x53302412
4. For each file that is a PDF or a JPG, it will create an entry in the output CSV containing the following information
	a. The full path to the file
	b. The actual file type (PDF or JPG)
	c. The MD5 hash of the file contents

Be sure to create a directory,a CSV file, JPG file(s) named 0xKTLM16 and PDF file(s) named 0x53302412 before starting the application.