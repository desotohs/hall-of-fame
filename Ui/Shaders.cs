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
    }
}
