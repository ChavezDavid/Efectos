﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace Efecto
{
    class Efecto1 : ISampleProvider
    {
        private ISampleProvider fuente;

        public float factor;

        public float Factor {
            get
            {
                return factor;
            }
            set
            {
                if (value > 1)
                    factor = 1;
                else if (value < 0)
                    factor = 0;
                factor = value;
            }
        }

        public Efecto1(ISampleProvider fuente)
        {
            this.fuente = fuente;
            Factor = 0.5f;
        }

        public Efecto1(ISampleProvider fuente, float factor)
        {
            this.fuente = fuente;
            Factor = factor;
            if (factor > 1)
                Factor = 1;
            else if (factor < 0)
                Factor = 0;
        }

        public WaveFormat WaveFormat
        {
            get
            {
                return fuente.WaveFormat;
            }
        }

        public int Read(float[] buffer, int offset, int count)
        {
            var read = fuente.Read(buffer, offset, count);

            for (int i = 0; i < read; i++)
            {
                //Efecto
                buffer[offset + i] *= Factor;
            }

            return read;
        }
    }
}