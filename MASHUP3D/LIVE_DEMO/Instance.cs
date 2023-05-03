using System.Collections.Generic;
using System.Linq;

namespace LIVE_DEMO
{
    public class Instance
    {
        public Model model;
        public List<MtxTransform> transformations;
        public Vertex position;
        public Mtx orientation;
        public float scale;
        public Mtx transform;
        public float scalation;
        public Vertex translation;
        public Vertex angle;
        public Mtx initialTransform;
        //Transformacion de Matriz

        public Instance(Model model, Vertex position, Mtx orientation = null, float scale = 1.0f)
        {
            this.model          = model;
            this.position       = position;
            this.orientation    = orientation ?? Mtx.Identity;
            this.scale          = scale;
            this.translation = new Vertex(0, 0, 0);
            this.transform = Mtx.MakeTranslationMatrix(this.position)* this.orientation * Mtx.MakeScalingMatrix(this.scale);
            initialTransform = transform;
            this.angle= new Vertex(0, 0, 0);
            this.transformations = new List<MtxTransform>();
            this.scalation = 1.0f;
        }
        public void SaveTransformations(int time)
        {
            transformations.Add(new MtxTransform(transform,time));
        }
        public MtxTransform FindTransformation(int time)
        {
            for(int i = 0; i < transformations.Count; i++)
            {
                if (transformations[i].time == time)
                    return transformations[i];
            }
            return null;
        }
        public void CalculateSteps(int initialFrame, int finalFrame)
        {
            float steps = finalFrame - initialFrame;
            MtxTransform initialTranformation = FindTransformation(initialFrame);
            MtxTransform finalTranformation = FindTransformation(finalFrame);
            if (steps > 0)
            {
                Mtx deltaTraslation = (finalTranformation.Mtx - initialTranformation.Mtx)/steps;
                
                for (int i = initialFrame; i < finalFrame; i++)
                {
                    transformations.Add(new MtxTransform(deltaTraslation*(i-initialFrame)+initialTranformation.Mtx,i));
                                      
                }
            }
           transformations = transformations.OrderBy(x => x.time).ToList();
        }

        }
}
