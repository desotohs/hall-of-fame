#!/bin/bash -i
set -e
cd "$(dirname "$0")"

sudo X &
export DISPLAY=:0
nvm use --delete-prefix node
node proxy.js
firefox "http://kpirankings.wixsite.com:3000/dhswildcats"
