abstract class SupportHandler
{
    protected SupportHandler NextHandler; 

    public void SetNextHandler(SupportHandler nextHandler)
    {
        this.NextHandler = nextHandler;
    }

    public virtual void HandleRequest(string request)
    {
        if (this.NextHandler != null)
        {
            this.NextHandler.HandleRequest(request);
        }
    }
}

class TechnicalSupportHandler : SupportHandler
{
    public override void HandleRequest(string request)
    {
        if (request == "technical")
        {
            Console.WriteLine("Technical support team will help you.");
        }
        else
        {
            base.HandleRequest(request);
        }
    }
}

class BillingSupportHandler : SupportHandler
    {
        public override void HandleRequest(string request)
        {
            if (request == "billing")
            {
                Console.WriteLine("Billing support team will help you.");
            }
            else
            {
                base.HandleRequest(request);
            }
        }
    }

    class GeneralSupportHandler : SupportHandler
    {
        public override void HandleRequest(string request)
        {
            if (request == "general")
            {
                Console.WriteLine("General support team will help you.");
            }
            else
            {
                base.HandleRequest(request);
            }
        }
    }

    class NoSupportHandler : SupportHandler
    {
        public override void HandleRequest(string request)
        {
            Console.WriteLine("Sorry, we cannot help you with that.");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {

            var technicalHandler = new TechnicalSupportHandler();
            var billingHandler = new BillingSupportHandler();
            var generalHandler = new GeneralSupportHandler();
            var noSupportHandler = new NoSupportHandler();
            technicalHandler.SetNextHandler(billingHandler);
            billingHandler.SetNextHandler(generalHandler);
            generalHandler.SetNextHandler(noSupportHandler);

            
            while (true)
            {
                Console.WriteLine("Which support do you need? (technical/billing/general)");
                var request = Console.ReadLine().ToLower();

                technicalHandler.HandleRequest(request); 
                Console.WriteLine();
            }
        }
        
    }

