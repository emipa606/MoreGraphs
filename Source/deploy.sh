#!/usr/bin/bash

shopt -s extglob

outputRoot="/c/Program Files (x86)/Steam/steamapps/common/RimWorld/Mods/MoreGraphs"

rm -rf "$outputRoot"
mkdir "$outputRoot"
cp -r ./!(Source|1.1) "$outputRoot"
mkdir -p "$outputRoot/1.1/Assemblies"
cp -r ./1.1/Assemblies/MoreGraphs.dll "$outputRoot/1.1/Assemblies"