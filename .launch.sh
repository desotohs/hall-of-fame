#!/bin/bash -i
set -e
cd "$(dirname "$0")"

sudo X &
export DISPLAY=:0
xrandr -o left
xinput set-prop 10 "Coordinate Transformation Matrix" 0 -1 1 1 0 0 0 0 1
nvm use --delete-prefix node
node proxy.js &
sleep 2s
firefox "http://kpirankings.wixsite.com:3000/dhswildcats"
(
    sleep 2s
    echo "press key 122"
    sleep 0.2s
    echo "release key 122"
    echo "exit"
) | java -cp bin deibert.zach.awtrobotshell.Main
