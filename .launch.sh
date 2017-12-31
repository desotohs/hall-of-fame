#!/bin/bash -i
set -e
cd "$(dirname "$0")"

sudo X &
export DISPLAY=:0
sleep 1s
xrandr -o left
sleep 1s
xinput set-prop 10 "Coordinate Transformation Matrix" 0 -1 1 1 0 0 0 0 1
