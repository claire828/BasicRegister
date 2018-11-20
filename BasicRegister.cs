using System;
using System.Collections.Generic;
using System.Reflection;


    public class BasicRegister<TEnum, TImplementation> 
    {
       
        private readonly Dictionary<TEnum, Type> RegisterMap = new Dictionary<TEnum, Type>();


        public void RegisterType(TEnum registedFrom, Type registedClass)
        {
            this.RegisterMap.Add(registedFrom, registedClass);
        }


        public TImplementation Resolve(TEnum from)
        {
            return Resolve(from,null);
        }


        public TImplementation Resolve(TEnum from, object[] arrs)
        {
            var implementation = RegisterMap[from];
             TImplementation instance = ( TImplementation)Activator.CreateInstance(implementation, arrs);
            return instance;
        }


        public void DisRegiester(TEnum from)
        {
            if (RegisterMap.ContainsKey(from))
            {
                RegisterMap.Remove(from);
            }

        }


    }



