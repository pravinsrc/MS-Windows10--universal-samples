<!---
  category: FilesFoldersAndLibraries
  samplefwlink: http://go.microsoft.com/fwlink/p/?LinkId=620549
--->

# HomeGroup sample

Shows how to use a HomeGroup to open, search, and share files. 
This sample uses some of the HomeGroup options found in the 
[Windows.Storage.Pickers](http://msdn.microsoft.com/library/windows/apps/br207928) and 
[Windows.Storage.KnownFolders](http://msdn.microsoft.com/library/windows/apps/br227151). 
In particular, it uses [Windows.Storage.Pickers.PickerLocationId](http://msdn.microsoft.com/library/windows/apps/br207890) 
enumeration and the [Windows.Storage.KnownFolders.homeGroup](http://msdn.microsoft.com/library/windows/apps/br227153) 
property to select files contained in a HomeGroup.

> **Note:** This sample is part of a large collection of UWP feature samples. 
> If you are unfamiliar with Git and GitHub, you can download the entire collection as a 
> [ZIP file](https://github.com/Microsoft/Windows-universal-samples/archive/master.zip), but be 
> sure to unzip everything to access shared dependencies. For more info on working with the ZIP file, 
> the samples collection, and GitHub, see [Get the UWP samples from GitHub](https://aka.ms/ovu2uq). 
> For more samples, see the [Samples portal](https://aka.ms/winsamples) on the Windows Dev Center. 

This sample covers the following processes:

-   How to open an item picker at a HomeGroup
-   How to search a HomeGroup
-   How to stream a video from a HomeGroup
-   How to conduct advanced searches in a HomeGroup

**Note** The Windows universal samples require Visual Studio 2017 to build and Windows 10 to execute.
 
To obtain information about Windows 10 development, go to the [Windows Dev Center](http://go.microsoft.com/fwlink/?LinkID=532421)

To obtain information about Microsoft Visual Studio and the tools for developing Windows apps, go to [Visual Studio](http://go.microsoft.com/fwlink/?LinkID=532422)

## Related topics

### Namespaces and classes

[Windows.Storage.Pickers](http://msdn.microsoft.com/library/windows/apps/br207928)  
[Windows.Storage.KnownFolders](http://msdn.microsoft.com/library/windows/apps/br227151)  
[Windows.Storage.Pickers.PickerLocationId](http://msdn.microsoft.com/library/windows/apps/br207890)  
[Windows.Storage.KnownFolders.HomeGroup](http://msdn.microsoft.com/library/windows/apps/br227153)  

### Samples

[BasicMediaCasting](../BasicMediaCasting/)  
[AdvancedCasting](../AdvancedCasting/)  

## System requirements

**Client:** Windows 10

**Server:** Windows Server 2016 Technical Preview

**Phone:** Windows 10

## Build the sample

1. If you download the samples ZIP, be sure to unzip the entire archive, not just the folder with the sample you want to build. 
2. Start Microsoft Visual Studio 2017 and select **File** \> **Open** \> **Project/Solution**.
3. Starting in the folder where you unzipped the samples, go to the Samples subfolder, then the subfolder for this specific sample, then the subfolder for your preferred language (C++, C#, or JavaScript). Double-click the Visual Studio Solution (.sln) file.
4. Press Ctrl+Shift+B, or select **Build** \> **Build Solution**.

## Run the sample

The next steps depend on whether you just want to deploy the sample or you want to both deploy and run it.

### Deploying the sample

- Select Build > Deploy Solution. 

### Deploying and running the sample

- To debug the sample and then run it, press F5 or select Debug >  Start Debugging. To run the sample without debugging, press Ctrl+F5 or select Debug > Start Without Debugging. 

