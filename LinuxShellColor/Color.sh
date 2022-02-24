#!/usr/bin/env bash
# Useage: CCout Color,String
function CCout()
{
    # Black 30
    if [ "$1" == "black" ]
    then
        echo -e "\033[30m$2\033[0m"
    # Red   31
    elif [ "$1" == "red" ]
    then
        echo -e "\033[31m$2\033[0m"
    # Green 32
    elif [ "$1" == "green" ]
    then
        echo -e "\033[32m$2\033[0m"
    # Yellow 33
    elif [ "$1" == "yellow" ]
    then
        echo -e "\033[33m$2\033[0m"
    # Blue   34
    elif [ "$1" == "blue" ]
    then
        echo -e "\033[34m$2\033[0m"
    # Grape  35
    elif [ "$1" == "grape" ]
    then
        echo -e "\033[35m$2\033[0m"
    # LightBlue 36 / deepgreen 36 | I don't know what color I see,Is this my problem?
    elif [ "$1" == "lightblue" ]
    then
        echo -e "\033[36m$2\033[0m"
    # White  37
    elif [ "$1" == "white" ]
    then
        echo -e "\033[37m$2\033[0m"
    # Error color
    else
        echo -e "\033[31m[X]\033[0m Do not have '$1' character color"
    fi
}