using System;
using System.Text;

namespace Com.GitHub.DesotoHS.HallOfFame.Ui {
    public static class Shaders {
        public static readonly Shader TextureShader = new Shader(@"
            #version 130

            uniform sampler2D tex;

            void main() {
                gl_FragColor = texture2D(tex, gl_TexCoord[0].st);
            }
        ", @"
            #version 130

            void main() {
                gl_TexCoord[0] = gl_MultiTexCoord0;
                gl_Position = ftransform();
            }
        ", (Gl, program) => {
            int loc = Gl.GetUniformLocation(program, Encoding.ASCII.GetBytes("tex\0"));
            Gl.Uniform1i(loc, 0);
        });

        public static readonly Shader FontShader = new Shader(@"
            #version 130

            in vec3 color;
            uniform sampler2D tex;

            void main() {
                gl_FragColor = vec4(color, texture2D(tex, gl_TexCoord[0].st).a);
            }
        ", @"
            #version 130

            out vec3 color;

            void main() {
                gl_TexCoord[0] = gl_MultiTexCoord0;
                gl_Position = ftransform();
                color = gl_Color.rgb;
            }
        ", (Gl, program) => {
            int loc = Gl.GetUniformLocation(program, Encoding.ASCII.GetBytes("tex\0"));
            Gl.Uniform1i(loc, 0);
        });
    }
}
