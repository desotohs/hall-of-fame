#!/bin/bash -i
set -e
cd "$(dirname "$0")"

sudo X &
export DISPLAY=:0
nvm use --delete-prefix node
node_modules/.bin/electron .
