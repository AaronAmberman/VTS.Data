# VTS
An API that contains a VTS mission file reader and writer for VTOL VR as well as data abstractions for runtime management of data.

The base namespace contains a KeywordStrings class and all the various keyword strings for the VTS file were moved there for easy management and access.

## VTS.Data.Raw
This namespace contains classes that enable the reader and writer to do their work reading and writing VTS files.

### VtsBaseObject
An abstract base class for VTS objects.

### VtsObject
The generic wrapper for all constructs in the VTS file. Contains children, parent and properties for easily traversable and searchable data.

### VtsCustomScenarioObject
The object wrapper for the all the generic objects and properties from inside the VTS file.

### VtsProperty
Represents any property on any object type from within the VTS file.

### VtsFileLineData
Helps manage and identify data in a line of text in the VTS file. Powers the reader in scrapping data from the VTS file to transcribe it to VTS objects.

## Objects
All objects (UnitSpawner, UnitFields, CONDITIONAL, EventInfo, etc.) will appear as children on the VtsCustomScenarioObject. Each object has properties that describe itself, children that are descendants of that object as well as a parent reference (this is not true for the VtsCustomScenarioObject as that is the root).

## VTS.File
This namespace contains classes that can be used to read and write VTS files.

### VtsWriter
The writer that reads the VtsCustomScenarioObject runtime object and writes its object graph to the VTS file. This type is static and only has 1 public method, *WriteVtsFile*.

### VtsReader
The reader that reads through the file and constructs the object graph from the file. This type is static and only has 1 public method, *ReadVtsFile*.

### VTS.Data.Raw Reading Usage
```
VtsCustomScenarioObject vtsCustomScenarioObject = VtsReader.ReadVtsFile(file);
```
Should be that easy to use.

### Reading Performance
It is a fast API but I am sure speed improvements could be made in places to make it even faster. The file I am testing is 14,766 lines of text. Here is a small table of performance tests on that file...

0.0434533

0.0400697

0.0422391

0.0415999

0.0397595

That is the largest file I have made. It is from [The Shlabovian Conflict](https://steamcommunity.com/sharedfiles/filedetails/?id=2366824583) (it is mission 5). The [VTOL Landing Practice](https://steamcommunity.com/sharedfiles/filedetails/?id=2866426564) mission I made produces a VTS file that is 3,369 lines long and it processes in about 0.011 consistently as well.

#### Growth and Future Expansion
VtsObject reading is built in such a way that future scalability should be fairly easy for newly added object types or removed object types in the VTS file. The reader and VtsObject are built generically so that as the file is read if an **object keyword** is found we recursively read that object and all its properties. This allows us to easily traverse objects in the VTS file and build the object graph. So when a new object type is added to the VTS file by some future version of VTOL VR the API only has to go into the KeywordStrings class in the base namespace and add a const for that string as it appears in the file and then add it to the read only collection of *ObjectStrings*. Then the VtsReader should identify that as an object type and treat it as something to be read recursively. The opposite is true for removed keywords that no longer appear. Remove the appropriate constants and then remove their reference in the collection of *ObjectStrings*. The Vtsreader will no longer see these as object types and will not construct child objects.

##### Note
Removing keywords isn't actually necessary if you desire backwards compatibility. The reason is because object types are matched when read. Meaning that if a keyword is present in the **ObjectStrings** collection if it is never read from the file then the object is still not constructed. The API does not construct objects it does not read from the file. Really up to you if you clone and use this repo. I, as the API writer, will by default leave them in for backwards compatibility.

### VTS.Data.Raw Writing Usage
Writing a VTS file is just as easy code wise.
```
bool success = VtsWriter.WriteVtsFile(vtsCustomScenarioObject, file);
```
#### Writing Note
Any data or structure validation should occur before the writer is writing. There is no validation here as the writer blindly writes what is present on the object and in its object graph.

### Writing Performance
Writing VTS files is very fast.
