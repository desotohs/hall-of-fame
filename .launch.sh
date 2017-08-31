#!/bin/bash
set -e
cd "$(dirname "$0")"

X &
export DISPLAY=:0
npm start
