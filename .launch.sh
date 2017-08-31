#!/bin/bash
set -e
cd "$(dirname "$0")"

sudo X &
export DISPLAY=:0
npm start
