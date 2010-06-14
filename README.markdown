## Welcome to Irrlicht.NET

Irrlicht.NET is a library to enable access from .NET languages to Irrlicht, the popular 3D engine.

Irrlicht.NET is a fork of and is based on the now discontinued Irrlicht.NETCP. The goal is to 
provide complete support for all of Irrlicht's functionality from .NET languages on both the 
Microsoft .NET Framework and Mono on Windows, Linux and MacOSX. 

In it's current form, Irrlicht.NET supports only Irrlicht 1.6, but one of the goals for this repository
is to change that situation by enabling easier rebasing to other branches.

## Getting the sources

First, clone this repository from github:

 git clone <repository address>

In the cloned working copy, update Irrlicht from upstream by issuing:

 git submodule init
 git submodule update

## Compilation

### Windows - Visual Studio

* Compile Irrlicht

  Go to the subdirectory 'irrlicht'. The appropriate branch of Irrlicht was automatically checked out
  for you when you cloned this repository. 
  Refer to http://irrlicht.sourceforge.net for information on compiling Irrlicht.

* Compile IrrlichtW

  Go to the subdirectory 'irrlichtw' and open irrlichtw.sln. Select the same configuration (Debug or 
  Release) as you built Irrlicht and Build Project.

* Compile Irrlicht.NET

  Go to the subdirectory 'irrlicht.net'. For Visual Studio 2008, execute runprebuild2008.bat, for Visual
  Studio 2010, execute runprebuild2010.bat This will create a solution file named Irrlicht.net.sln, which
  you can open and build in Visual Studio.
  
* Compile the samples

  Go to the subdirectory 'samples'. As above run either runprebuild2008.bat or runprebuild2010.bat, which will
  create Irrlicht.samples.sln. Open this solution file in Visual Studio and Build.
  
### Windows - CodeBlocks

Coming later

### Linux and MacOSX

Coming later

## Running samples

To be able to run the samples, you will have to copy the Irrlicht.dll from 'irrlicht/bin/Win32-VisualStudio/ to
bin/<Debug or Release>/

## Documentation

API documentation is not yet automatically generated, for now please refer to the source code.

## Bugs

There are plenty. Some small, some significant. Some would require changes to how Irrlicht works, especially when
it comes to IReferenceCounted. If you find a bug, please add it as an issue on github: 
http://github.com/zaki/irrlicht.net/issues

## Contribute

If you want to work on or help work on Irrlicht.NET, you have a few options. First of all, the license if very
permissible, so if you want to run with it, go ahead, fork the project, fix it yourself. Of course contributing
patches back to http://github.com/zaki/irrlicht.net would be nice and very welcome. Receiving commit access to the
repository is also an option.
