#!/bin/bash

mono ../bin/Release/Prebuild.exe /target nant
mono ../bin/Release/Prebuild.exe /target vs2008

