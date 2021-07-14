[![NuGet Icon](https://upload.wikimedia.org/wikipedia/commons/thumb/2/25/NuGet_project_logo.svg/364px-NuGet_project_logo.svg.png)](https://www.nuget.org/)

# NuGet 101

NuGet (pronounced "New Get") is the official package manager for the .NET developer platform.
That means NuGet hosts a massive ecosystem of packages at nuget.org and
provides tools to help developers create, publish, and consume .NET packages!

- [NuGet Package with the .NET CLI](https://github.com/afgalvan/101-dotnet/blob/main/NuGet/README.md#nuget-package-with-the-net-cli)

- [Create and Publish a NuGet Package with the .NET CLI](https://github.com/afgalvan/101-dotnet/blob/main/NuGet/README.md#create-and-publish-a-nuget-package-with-the-net-cli)
  
## NuGet Package with the .NET CLI

An introduction to installing and using NuGet packages with cross-platform
.NET CLI. We will walk through an example of converting a mascot object to
a JSON string and cover how to search for, install, and use a NuGet package
with .NET CLI commands and nuget.org.

### Install a package

`dotnet add package` adds a package reference to the project file, then runs
`dotnet restore` to install the package.

1. Open a command line and switch to the directory that contains your project file.
2. Use the following command to install a NuGet package:
```bash
dotnet add package <PACKAGE_NAME>
```

#### Install a specific version of a package

If the version is not specified, NuGet installs the latest version of
the package. You can also use the `dotnet add package` command to install
a specific version of a NuGet package:
```bash
dotnet add package <PACKAGE_NAME> --version <VERSION>
```

### List package references

You can list the package references for your project using:
```bash
dotnet list package
```

### Uninstall a package

Use the dotnet remove package command to remove a package reference from the project file.
```
dotnet remove package <PACKAGE_NAME>
```

## Create and Publish a NuGet Package with the .NET CLI

Creating NuGet packages with the .NET CLI and publishing to nuget.org.
In this tutorial we will build a simple class library from scratch, use
good practices to fill out the package metadata, and generate a package
with the .NET CLI. To finish it off, we’ll publish our package to nuget.org!

### Package manifests

#### Using a csproj file

The following properties are required to create a package.

- `PackageId`, the package identifier, which must be unique across the gallery that hosts the package. If not specified, the default value is `AssemblyName`.
- `Version`, a specific version number in the form *Major.Minor.Patch[-Suffix]* where *-Suffix* identifies pre-release versions. If not specified, the default value is 1.0.0.
- The package title as it should appear on the host (like nuget.org)
- `Authors`, author and owner information. If not specified, the default value is `AssemblyName`.
- `Company`, your company name. If not specified, the default value is `AssemblyName`.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net5.0</TargetFramework>
    <PackageId>Company.Product.Feature</PackageId>
    <Version>1.0.0</Version>
    <Authors>your_name</Authors>
    <Company>your_company</Company>
      
    <Description>A package description</Description>
    <PackageLicenseExpression>MIT</PackageLicenseExpression>
    <PackageTags>Some, Tags</PackageTags>
    <RepositoryUrl>https://github.com/user/repository</RepositoryUrl>
  </PropertyGroup>
</Project>
```

#### Using a nuspec file

- Generate nuspec file
```bash
nuget spec <PACKAGE_NAME>
```
- Change Manifest (.nuspec)
```xml
<?xml version="1.0" encoding="utf-8"?>
<package xmlns="http://schemas.microsoft.com/packaging/2010/07/nuspec.xsd">
  <metadata>
    <id>Company.Utilities.Feature</id>
    <title>Your package title</title>
    <version>1.0.0</version>
    <authors>your_name</authors>
    <owners>your_name</owners>
      
    <description>Some description</description>
    <projectUrl>https://github.com/user/repository</projectUrl>
    <repository type="git" url="https://github.com/user/repository" />
    <license type="expression">MIT</license>
    <releaseNotes>A release note</releaseNotes>
   <!--
   <packageTypes>
      <packageType name="Template" />
    </packageTypes>
    -->
    <tags>Some Tags</tags>
    <copyright>Copyright 2021</copyright>
  </metadata>
  <!--
  <files>
    <file src=".\**" target="content" exclude="**\bin\**;*.nuspec;*.config;**\obj\**;**\.git\**;**\.github\workflows\publish.yml;**\*.user;**\.idea\**;**\.vscode\**;\**\.template.config\**" />
  </files>
  -->
</package>
```

### Create a package

#### Using a csproj file

```
dotnet pack
```

#### Using a nuspec file

```bash
nuget pack <PACKAGE_NAME>.nuspec
```

### Publish a package

For nuget.org, you must sign in with a Microsoft account,
with which you'll be asked to register the account with nuget.org.

![nuget.org top bar](https://docs.microsoft.com/en-us/nuget/nuget-org/media/publish_nugetsignin.png)

#### Publish from the command line

##### Create API keys

1. Sign into your nuget.org account or create an account if you don't have one already.
2. Select your user name (on the upper right), then select API Keys.
3. Select Create, provide a name for your key, select Select Scopes > Push.
   Enter * for Glob pattern, then select Create. (See below for more about scopes.)
4. Once the key is created, select Copy to retrieve the access key you need in the CLI:
![nuget.org api key section censored](https://docs.microsoft.com/en-us/nuget/quickstart/media/qs_create-02-apikey.png)
5. **Important:** Save your key in a secure location because you cannot
   copy the key again later on. If you return to the API key page, you need to
   regenerate the key to copy it. You can also remove the API key if you no
   longer want to push packages via the CLI.

##### Publish with dotnet nuget push

1. Change to the folder containing the .nupkg file.
2. Run the following command, specifying your package name (unique package ID) and replacing the key value with your API key:
   ```bash
   dotnet nuget push <YOUR_PACKAGE>.1.0.0.nupkg --api-key <YOUR_API_KEY> --source https://api.nuget.org/v3/index.json
   ```

#### Publish from the browser

1. Select Upload on the top menu of nuget.org and browse to the package location.
![nuget.org publish package option](https://docs.microsoft.com/en-us/nuget/nuget-org/media/publish_uploadyourpackage.png)
2. nuget.org tells you if the package name is available. If it isn't, change the package identifier in your project, rebuild, and try the upload again.
3. If the package name is available, nuget.org opens a Verify section in which you can review the metadata from the package manifest. If you included a readme file in your package, check out the preview to ensure all content is being rendered properly. To change any of the metadata, edit your project (project file or .nuspec file), rebuild, recreate the package, and upload again.
4. When all the information is ready, select the Submit button
![NuGet Alt Logo](https://miro.medium.com/max/512/1*XhYXEAUsRVdyma5MjQn6lg.png)
