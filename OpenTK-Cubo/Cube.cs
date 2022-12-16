namespace OpenTK_Cubo
{
    public class Cube
    {
        public float[] vertice; //A cada 7 Vérticce vec3(x,y,z) e cor
        public uint[] indices;

        public Cube()
        {
            vertice = new float[]
            {
                -0.5f,  0.5f,  0.5f,  1.0f, 0.0f, 0.0f, 1.0f,  // top    left  front
                -0.5f, -0.5f,  0.5f,  0.0f, 1.0f, 0.0f, 1.0f,  // bottom left  front
                 0.5f, -0.5f,  0.5f,  0.0f, 0.0f, 1.0f, 1.0f,  // bottom right front
                 0.5f,  0.5f,  0.5f,  1.0f, 1.0f, 1.0f, 1.0f,  // top    right  front

                -0.5f,  0.5f, -0.5f,  0.0f, 0.0f, 1.0f, 1.0f,  // top    left  back
                -0.5f, -0.5f, -0.5f,  1.0f, 1.0f, 1.0f, 1.0f,  // bottom left  back
                 0.5f, -0.5f, -0.5f,  1.0f, 0.0f, 0.0f, 1.0f,  // bottom right back
                 0.5f,  0.5f, -0.5f,  0.0f, 1.0f, 0.0f, 1.0f   // top    right  back
            };

            indices = new uint[]
            {
                0, 1, 2, //Face
                0, 2, 3,

                4, 0, 3, //Up
                4, 3, 7,

                3, 2, 6, //Right
                3, 6, 7,

                0, 5, 1, //Left
                0, 4, 5,

                1, 5, 6, //Down
                1, 6, 2,

                4, 6, 5, //Back
                4, 7, 6
            };
        }

    }

}