#!/bin/bash -i

git pull
nvm use --delete-prefix node
npm run build
sudo reboot
