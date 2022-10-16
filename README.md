# VTS.Data
An API that contains a VTS mission file reader and writer for VTOL VR as well as data abstractions for runtime management of data.

## At a Glance
It is a very small and lightweight API that only has a handful of types that make it work.

### Strings
All the various keyword strings for the VTS file were moved into their own class for easy management.

### VtsWriter
The writer that reads the runtime object and writes the object graph to the file. This type is static and only has 1 public method, *WriteVtsFile*.

### VtsReader
The reader that reads through the file and constructs the object graph from the file. This type is static and only has 1 public method, *ReadVtsFile*.

### VtsFileLineData
Helps manage and identify data in a line of text in the file.

### VtsProperty
Represents any property on any object type from within the VTS file.

### VtsBaseObject
An abstract base class for VTS objects.

### VtsCustomScenarioObject
The object wrapper for the all the generic objects and properties from inside the VTS file.

### VtsObject
The generic wrapper for all constructs in the VTS file. Contains children, parent and properties for easily traversable and searchable data.

## Objects
All objects (UnitSpawner, UnitFields, CONDITIONAL, EventInfo, etc.) will appear as children on the VtsCustomScenarioObject. Each object has properties that describe itself, children that are descendants of that object as well as a parent reference (this is not true for the VtsCustomScenarioObject as that is the root).

### Reading Usage
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

### Writing Usage
Writing a VTS file is just as easy code wise.
```
bool success = VtsWriter.WriteVtsFile(vtsCustomScenarioObject, file);
```
#### Writing Note
Any data or structure validation should occur before the writer is writing. There is no validation here as the writer blindly writes what is present on the object and in its object graph.

### Writing Performance
Writing VTS files is very fast.
