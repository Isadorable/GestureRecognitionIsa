using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GestureForKinect.Djestit
{
    public class CompositeTerm : Term
    {
        public List<Term> children;

        public override void reset()
        {
	        this.state = expressionState.Default;
	        foreach(var child in this.children)
	        {
		        child.reset();
	        }
        }

        public override void error(Token token)
        {
            this.state = expressionState.Error;
            foreach (var child in this.children)
            {
                child.error(token);
            }
        }

    }
}
