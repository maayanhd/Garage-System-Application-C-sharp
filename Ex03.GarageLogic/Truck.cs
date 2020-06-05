﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public sealed class Truck : Vehicle
     {
          private bool m_IsCarryingDangerousMaterials;
          private float m_CarryingSize;
          private static readonly int sr_NumOfWheels = 16;
          private GasEngine m_Engine;

          public Truck(string i_LicenseNumber, GasEngine i_GasEngine) : base(i_LicenseNumber)
          {
               base.ManageMemberInfo();

               for (int i = 0; i < sr_NumOfWheels; i++)
               {
                    Wheels.Add(new Wheel(28));
               }

               m_Engine = i_GasEngine;
               m_Engine.FuelType = GasEngine.eFuelType.Soler;
               m_Engine.MaximumAmountOfFuelInLitters = 120;

          }

          public override void ManageMemberInfo()
          {
               base.ManageMemberInfo();
               m_MemberInfoStr.Add("whether the truck carrying dangerous materials");
               m_MemberInfoStr.Add("whether the truck carrying dangerous materials");
               m_MemberInfoStr.Add(m_Engine.CurrentAmountInfoStr);
          }

          //****************Validations Methods******************//  
          public override bool IsCurrentMemberValid(int i_NumOfField, string i_InputStr)
          {
               bool isMemberValid = false;

               if (base.IsCurrentMemberValid(i_NumOfField, i_InputStr))
               {
                    // The number of cases of vehicle is 3 + 2 * numofwheels  

                    switch (i_NumOfField - (3 + 2 * this.Wheels.Count))
                    {
                         case 1:
                              isMemberValid = i_InputStr.Equals("Yes") == true || i_InputStr.Equals("No");
                              break;
                         case 2:
                              isMemberValid = float.TryParse(i_InputStr, out float io_CarryingSize) == true ? IsCarryingSizeValid(io_CarryingSize) : false;
                              break;
                         case 3:
                              isMemberValid = float.TryParse(i_InputStr, out float io_AmountOfMaterial) == true ? TruckEngine.IsAmountsOfSourcePowerMaterialValid(io_AmountOfMaterial) : false;
                              break;
                    }

               }

               return isMemberValid;

          }

          public static bool IsCarryingSizeValid(float i_CarryingSize)
          {

               return i_CarryingSize > 0;

          }

          // New- update in flow chart
          //****************Assigning Methods******************//  

          void AssignIsCarryingDangerousMaterials(string i_IsCarryingDangerousMaterials)
          {
               if (i_IsCarryingDangerousMaterials.Equals("Yes") == false && i_IsCarryingDangerousMaterials.Equals("No") == false)
               {
                    throw new FormatException("Please enter Yes or No only");
               }
               else
               {
                    IsCarryingDangerousMaterials = i_IsCarryingDangerousMaterials.Equals("Yes") == true;
               }

          }

          void AssignCarryingSize(string i_CarryingSize)
          {

               if (float.TryParse(i_CarryingSize, out float io_CarryingSize) == false)
               {
                    throw new FormatException("The Carrying size should be a decimal number");
               }
               else
               {
                    CarryingSize = io_CarryingSize;
               }

          }
          
          //****************Properties******************//  
          public bool IsCarryingDangerousMaterials
          {
               get
               {
                    return m_IsCarryingDangerousMaterials;
               }

               set
               {
                    m_IsCarryingDangerousMaterials = value;
               }

          }

          public float CarryingSize
          {
               get
               {
                    return m_CarryingSize;
               }

               set
               {
                    m_CarryingSize = value;
               }

          }

          public GasEngine TruckEngine
          {
               get
               {
                    return m_Engine;
               }

               set
               {
                    m_Engine = value;
               }

          }

     }

}
