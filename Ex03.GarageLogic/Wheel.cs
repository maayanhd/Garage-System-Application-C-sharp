﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class Wheel
     {
          private string m_Manufacturer;
          private float m_CurrentWheelPressure;
          private float m_MaximalWheelPressure;

          public Wheel(float i_MaxPressure)
          {
              m_CurrentWheelPressure = 0;
              m_MaximalWheelPressure = i_MaxPressure;
          }

          public override string ToString()
          {
              StringBuilder strToReturn = new StringBuilder();

              strToReturn.AppendLine(
                  string.Format(
                      "Manufacturer: {0}",
                      Manufacturor));
              strToReturn.AppendLine(
                  string.Format(
                      "Current wheel pressure: {0} out of {1} possible",
                      CurrentWheelPressure,
                      MaximalWheelPressure));
              return strToReturn.ToString();
          }

          public bool IsManufacturerValid(string i_Manufacorer)
          {
               bool isValid = false;

               foreach (char ch in i_Manufacorer)
               {
                    isValid = char.IsLetter(ch);

                    if (isValid == false)
                    {
                         break;
                    }
               }

               return isValid;
          }

          public float GetAmountOfPressurePossibleToInflate()
          {
              return MaximalWheelPressure - CurrentWheelPressure;
          }

          public bool IsAirPressureIsValid(float i_AirPressure)
          {
              return i_AirPressure <= m_MaximalWheelPressure - m_CurrentWheelPressure && i_AirPressure >= 0;
          }

          public void InflateToMaximum()
          {
              Inflate(m_MaximalWheelPressure - m_CurrentWheelPressure);
          }

          public void Inflate(float i_AirToAdd)
          {
              if(IsAirPressureIsValid(i_AirToAdd))
              {
                  m_CurrentWheelPressure += i_AirToAdd;
              }
              else
              {
                  throw new ValueOutOfRangeException(m_MaximalWheelPressure - m_CurrentWheelPressure, 0);
              }
          }

          internal float MaximalWheelPressure
          {
              get
              {
                  return m_MaximalWheelPressure;
              }

              set
              {
                  m_MaximalWheelPressure = value;
              }
          }

          public string Manufacturor
          {
              get
              {
                  return m_Manufacturer;
              }

              set
              {
                  if (IsManufacturerValid(value) == true)
                  {
                      m_Manufacturer = value;
                  }
                  else
                  {
                      throw new FormatException("The Manufacturer should consist only letters");
                  }
              }
          }

          public float CurrentWheelPressure
          {
              get
              {
                  return m_CurrentWheelPressure;
              }

              set
              {
                  if(CurrentWheelPressure <= MaximalWheelPressure)
                  {
                      m_CurrentWheelPressure = value;
                  }
                  else
                  {
                      throw new ValueOutOfRangeException(MaximalWheelPressure - CurrentWheelPressure, 0);
                  }
              }
          }
    }
}