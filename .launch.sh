#!/bin/bash -i
set -e
cd "$(dirname "$0")"

sudo X &
export DISPLAY=:0
sleep 1s
xrandr -o left
nvm use --delete-prefix node
node proxy.js &
sleep 1s
firefox "http://kpirankings.wixsite.com:3000/dhswildcats" &
(
    sleep 2s
    echo "press key 122"
    sleep 0.2s
    echo "release key 122"
    echo "exit"
) | java -cp AWTRobotShell/bin deibert.zach.awtrobotshell.Main
xinput set-prop 10 "Coordinate Transformation Matrix" 0 -1 1 1 0 0 0 0 1
for win in $(xdotool search --onlyvisible --name firefox); do
    xdotool windowsize $win 1080 1920
    xdotool windowmove $win 0 0
done
