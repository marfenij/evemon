﻿using System.Linq;
using EVEMon.Common.Collections;
using EVEMon.Common.Serialization.Datafiles;

namespace EVEMon.Common.Data
{
    public sealed class EvePropertyCollection : ReadonlyCollection<EvePropertyValue>
    {
        #region Constructor

        /// <summary>
        /// Deserialization consructor.
        /// </summary>
        /// <param name="src"></param>
        internal EvePropertyCollection(SerializablePropertyValue[] src)
            : base(src == null ? 0 : src.Length)
        {
            if (src == null)
                return;

            Items.Capacity = src.Length;
            foreach (var srcProp in src)
            {
                EvePropertyValue prop = new EvePropertyValue(srcProp);
                if (prop.Property != null)
                    Items.Add(prop);
            }
            Items.Trim();
        }

        #endregion


        #region Indexers

        /// <summary>
        /// Gets a property from its name. If not found, return null.
        /// </summary>
        /// <param name="property">The property we're searching for.</param>
        /// <returns>The wanted property when found; null otherwise.</returns>
        public EvePropertyValue? this[EveProperty property]
        {
            get
            {
                foreach (EvePropertyValue prop in Items.TakeWhile(prop => prop.Property != null)
                    .Where(prop => prop.Property == property))
                {
                    return prop;
                }
                return null;
            }
        }

        /// <summary>
        /// Gets a property from its name. If not found, return null.
        /// </summary>
        /// <param name="id">The property id we're searching for.</param>
        /// <returns>The wanted property when found; null otherwise.</returns>
        public EvePropertyValue? this[int id]
        {
            get
            {
                foreach (EvePropertyValue prop in Items.TakeWhile(prop => prop.Property != null)
                    .Where(prop => prop.Property.ID == id))
                {
                    return prop;
                }
                return null;
            }
        }

        #endregion
    }
}