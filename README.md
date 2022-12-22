# VTS
An API that contains a VTS mission file reader and writer for VTOL VR as well as data abstractions for runtime management of data.

The base namespace contains a KeywordStrings class and all the various keyword strings for the VTS file were moved there for easy management and access. *Note: not 100% of strings exist in this file but all major strings used by the *Raw* namespace exist. In the future 100% of all strings that come the VTS file will be moved into here.*




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
VtsObject reading is built in such a way that future scalability should be fairly easy for newly added object types or removed object types in the VTS file. The reader and VtsObject are built generically so that as the file is read if an **object keyword** is found we recursively read that object and all its properties. This allows us to easily traverse objects in the VTS file and build the object graph. So when a new object type is added to the VTS file by some future version of VTOL VR the API only has to go into the KeywordStrings class in the base namespace and add a const for that string as it appears in the file and then add it to the read only collection of *ObjectStrings*. Then the VtsReader should identify that as an object type and treat it as something to be read recursively. The opposite is true for removed keywords that no longer appear. Remove the appropriate constants and then remove their reference in the collection of *ObjectStrings*. The VtsReader will no longer see these as object types and will not construct child objects.

##### Note
Removing keywords isn't actually necessary if you desire backwards compatibility. The reason is because object types are matched when read. Meaning that if a keyword is present in the **ObjectStrings** collection but it is never read from the file then the object is still not constructed. The API does not construct objects it does not read from the file. Really up to you if you clone and use this repo. I, as the API writer, will by default leave them in for backwards compatibility.

### VTS.Data.Raw Writing Usage
Writing a VTS file is just as easy code wise.
```
bool success = VtsWriter.WriteVtsFile(vtsCustomScenarioObject, file);
```
#### Writing Note
Any data or structure validation should occur before the writer is writing. There is no validation here as the writer blindly writes what is present on the object and in its object graph.

### Writing Performance
Writing VTS files is very fast.




## VTS.Data.Abstractions
This namespace contains types that attempt to add a data structure that is similar to the VTS file itself.

For the most part these types should not be used directly in your code. These types are the middle layer between the VTS raw data objects and the *Runtime* namespace objects.

### CustomScenario 
This cloneable type contains all the magic needed for this namespace. Not only is it the outer data container but it also houses all the read and write methods that convert these objects back to VTS objects so the reader and writer can properly interpret the data for file writing. See the static methods ReadVtsFile and WriteVtsFile for more information.

All other types are cloneable data containers with the exception of UnitFields. This type contains mappings for unit types and unit field properties.




## VTS.Data.Runtime
This namespace contain types that attempt to add even more structure to the data by making object references instead of relying on id pointers and magic strings.

### CustomScenario
This cloneable type contains all the magic needed for this namespace. Not only is it the outer container but it also houses the read and save methods that interpret data from the *Abstractions* namespace.

#### X,Y,Z Position Data Warning
I could not quite get the string formatting to work correctly going from a string to a Single back to a string when interpreting the data and writing it again. So some of the positions have rounded data down to 3 decimal places, some don't. It is on the todo list but not letting good get in the way of progress and getting some work done on the [mission assistant](https://github.com/AaronAmberman/VTOLVR-MissionAssistant.git).

*Note: you will notice a lot of duplicated types between the Abstraction namespace and the Runtime namespace. I thought this design would be better in terms of how I was trying to layer the data interpretation. Though I probably could have made the Runtime types inherit the Abstraction types if I would have made the Clone method virtual. Maybe something for the future but no real plans there.*


## VTS.Data.Diagnostics
This namespace that contain types that assist in outputting some additional data that is not apart of the data structures. 




# The Usage You Want
![Usage](https://user-images.githubusercontent.com/23512394/209232581-20c02531-bb03-46ac-ab5b-a93a3a27ce43.png)

Which will get you an an object that looks like this...

![CustomScenario](https://user-images.githubusercontent.com/23512394/209232624-8bd12a19-af34-4db0-9e18-2127fa0f2a08.png)

## Generated Warnings
In the debug console you will notice some data warning that come from the API as well. There seems to be some bugs in VTOL VR when it comes to verifying the data being written to the VTS file. So I have added some validation checks to the code and spit out warnings. The types of warnings...

1. VTS.Data.Runtime.CustomScenario No Matching Id Data Warning
   - This is generated when any construct attempts to reference another construct and that secondary construct could not be found. There are many situations in which this can occur.
2. VTS.Data.Runtime.CustomScenario UnitGroup Data Warning
   - This occurs when one of 4 types of errors occurs reading unit group data.
     - The unit group {group} references unit {unitId} and that unit could not be found in the list of Units 
     - The unit {unitId} is not assigned to the correct group. Unit is supposed to be included in {actual-group} but it is listed in {group} incorrectly.
     - The unit {unitId} is not assigned to the correct larger group of groups. Current group: {larger-group}, listed group for unit: {group}. This means an Allied unit appeared in a Enemy group or Enemy unit appeared in an Allied group.
     - unit {unitName} (unitInstanceID) is already a part of this group. Duplicate ID entry for the same unit within the same group ({group}).
3. VTS.Data.Runtime.CustomScenario Data Conversion Warning
   - This occurs within this API when attempting to cast between expected types and the cast fails.
  
There are plans in the future to add the ability to push these warning to the consuming application so that they be logged...or whatever it is that the consuming application wishes to do with the warning. 
