#!/bin/bash

git pull
nvm use --delete-prefix node
npm run build
sudo reboot
