#!/bin/bash -i

git pull
nvm use --delete-prefix node
npm install
npm run build
sudo reboot
