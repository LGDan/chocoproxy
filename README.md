# chocoproxy
Caching proxy for the chocolatey software automation platform community repo.

## What is this?
If you know what chocolatey is, and you (don't want to|don't have the resources to) go through the process of setting up the infrastructure for a proper nuget package repository, and you don't need to push your own packages, this may be for you. 

ChocoProxy essentially allows you to host your own chocolatey API and package storage repo on your own systems rather than hammering their official ones, with very little configuration.

## Features
### Current
* Caching of all requests to https://chocolatry.org/api/v2/* for a configurable amount of time.
  - This includes package metadata, search results, and package redirections.
* Caching of chocolatey packages to a specified location on disk.
* Basic API for gathering statistics about the proxy cache (hits, objects, expiry etc.)

### Planned / In Progress
* Automated addition of chocolatey packages to SCCM's Application List
* Automated update of SCCM Deployment Types for new version detection

## Why?
Where I work, there's a requirement for people to use a lot of software. And I mean a lot. 300+ applications on a single machine is not uncommon. IT are already bogged down dealing with enough issues, and do not have the resourcing to keep a huge library of applications up to date all the time. This is where I found the benefits of chocolatey to come in handy. Choco + SCCM makes installing applications very easy, but it would be unfair to have all our clients hammer their infrastructure - especially the community repo (which is where the majority of people are installing things from). There's also the issues of validating the packages to ensure they aren't compromised.

I wasn't asked by my company to build this, and I've just spent a weekend in my own time putting this together as it will save people a lot of time, and realised many other sysadmins and IT personnel could benefit from it, and improve it.

## Usage
As this is pretty early in development, I haven't yet got a build/release pipeline set up, so you'll have to compile it youself.

1. Get Visual Studio 2019
2. Get Chocolatey
3. Clone or download the project.
4. Open the .sln file and hit F5
5. Open a terminal and run a choco command, but specify <br>
   `--source="'http://localhost:44111/api/v2/'"`<br>
   at the end.
6. Watch ChocoProxy cache all the requests.
7. Run the same command a second time and you'll see that not a single call goes out to the internet. The cache is set for 24 hours.

Currently it's only set to listen on localhost, you can change this but it may require you running it as admin for lower port numbers, or creating firewall exceptions.

## Screenshots
![Command Line Screenshot](https://i.imgur.com/jO6szD6.png)