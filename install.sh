#!/bin/bash
set -e
cd "$(dirname "$0")"

sudo apt update
sudo apt install $(cat apt.txt)
sudo apt upgrade

git submodule init
git submodule update
cd AWTRobotShell/src
javac -d ../bin $(find -name "*.java")
cd ../..
nvm use --delete-prefix node
npm install
