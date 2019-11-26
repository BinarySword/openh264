// Copyright 1998-2015 Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;

public class OpenH264 : ModuleRules
{
    public OpenH264(TargetInfo Target)
    {

        Type = ModuleType.External;

        PublicIncludePaths.AddRange(
            new string[]
            {
                "ThirdParty/OpenH264/codec/api/svc",//Relative To "Source" Folder
                "/usr/local/include"
				// ... add public include paths required here ...
			}
            );


        PrivateIncludePaths.AddRange(
            new string[]
            {
               "ThirdParty/OpenH264/codec/api/svc",//Relative To "Source" Folder
                "/usr/local/include"
				// ... add other private include paths required here ...
			}
            );


        PublicDependencyModuleNames.AddRange(
            new string[]
            {
                "Core",
                "CoreUObject",
                "Engine"
				// ... add other public dependencies that you statically link with here ...
			}
            );


        PrivateDependencyModuleNames.AddRange(
            new string[]
            {
                "UnrealEd",
                "LevelEditor",
                "Slate", "SlateCore",
                "UMG"
				// ... add private dependencies that you statically link with here ...	
			}
            );

        DynamicallyLoadedModuleNames.AddRange(
            new string[]
            {
            }
            );


        string LibName = "";
        string OpenH264LibraryPath = "";
        string SystemLibraryPath = "";
        string OpenH264BinariesPath = "";

        if (Target.Platform == UnrealTargetPlatform.Win64)
        {
            LibName = "openh264";
            OpenH264LibraryPath = ModuleDirectory + "/Binaries/x64/Release/Windows";
            OpenH264BinariesPath = ModuleDirectory + "/Binaries/x64/Release/Windows";
        }

        else if (Target.Platform == UnrealTargetPlatform.Mac)
        {
            LibName = "libopenh264";
            SystemLibraryPath = "/usr/lib";
            OpenH264LibraryPath = ModuleDirectory + "/Binaries/x64/Release/Mac";
        }

        if (Target.Platform == UnrealTargetPlatform.Win64)
        {

            PublicLibraryPaths.AddRange(
            new string[]
            {
                OpenH264LibraryPath
            }
            );

            PublicAdditionalLibraries.AddRange(
                new string[]
                {
                    LibName + ".lib"
                }
                );

            string DLLName = LibName + ".dll";
            PublicDelayLoadDLLs.Add(DLLName);
            RuntimeDependencies.Add(new RuntimeDependency(OpenH264BinariesPath + "/" + DLLName));

            Definitions.AddRange(
                new string[]
                {
                }
                );
        }

        else if (Target.Platform == UnrealTargetPlatform.Mac)
        {
            PublicLibraryPaths.AddRange(
            new string[]
            {
                OpenH264LibraryPath,
                SystemLibraryPath,
            }
            );

            PublicAdditionalLibraries.AddRange(
                new string[]
                {
                    LibName + ".a",
                }
                );

            Definitions.AddRange(
                new string[]
                {
                }
                );
        }

        //Force No Debug Information In Development Builds.
        BuildConfiguration.bOmitPCDebugInfoInDevelopment = true;
    }
}
