#version 330 core

out vec4 outputColor;

in vec4 ourColor;
//uniform vec4 ourColor;

void main()
{
    outputColor = ourColor;
}