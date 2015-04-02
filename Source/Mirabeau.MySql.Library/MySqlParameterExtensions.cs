﻿using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Mirabeau.MySql.Library
{
    /// <summary>
    /// Extension methods for <see cref="MySqlParameter"/>.
    /// </summary>
    public static class MySqlParameterExtensions
    {
        private static readonly MySqlParameterFactory Factory = new MySqlParameterFactory();

        /// <summary>
        /// Uses the <see cref="ICloneable"/>Interface to clone a <see cref="MySqlParameter"/>.
        /// </summary>
        /// <param name="parameter">The SQL parameter.</param>
        /// <returns>The <see cref="MySqlParameter"/></returns>
        public static MySqlParameter Clone(this MySqlParameter parameter)
        {
            ICloneable cloneable = parameter;
            return cloneable == null ? null : cloneable.Clone() as MySqlParameter;
        }

        /// <summary>
        /// Creates a MySqlParameter with either DBNull or a value.
        /// </summary>
        /// <param name="nullableObject">The nullable object.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>The <see cref="MySqlParameter"/></returns>
        public static MySqlParameter CreateMySqlParameter<T>(this T? nullableObject, string parameterName) where T : struct
        {
            return Factory.CreateParameter(nullableObject, parameterName);
        }

        /// <summary>
        /// Creates a MySqlParameter with either DBNull or a value
        /// </summary>
        /// <param name="theValue">The value.</param>
        /// <param name="parameterName">The name of the parameter</param>
        /// <returns>The <see cref="MySqlParameter"/></returns>
        public static MySqlParameter CreateMySqlParameter(this string theValue, string parameterName)
        {
            return Factory.CreateParameter(theValue, parameterName);
        }

        /// <summary>
        /// Creates a MySqlParameter with either DBNull or a value
        /// </summary>
        /// <param name="theValue">The value.</param>
        /// <param name="parameterName">The name of the parameter</param>
        /// <returns>The <see cref="MySqlParameter"/></returns>
        public static MySqlParameter CreateMySqlParameter(this int? theValue, string parameterName)
        {
            return Factory.CreateParameter(theValue, parameterName);
        }

        /// <summary>
        /// Creates a MySqlParameter
        /// </summary>
        /// <param name="theValue">The value.</param>
        /// <param name="parameterName">The name of the parameter</param>
        /// <returns>The <see cref="MySqlParameter"/></returns>
        public static MySqlParameter CreateMySqlParameter(this int theValue, string parameterName)
        {
            return Factory.CreateParameter(theValue, parameterName);
        }

        /// <summary>
        /// Creates a MySqlParameter with either DBNull or a value
        /// </summary>
        /// <param name="theValue">The value.</param>
        /// <param name="parameterName">The name of the parameter</param>
        /// <returns>The <see cref="MySqlParameter"/></returns>
        public static MySqlParameter CreateMySqlParameter(this decimal? theValue, string parameterName)
        {
            return Factory.CreateParameter(theValue, parameterName);
        }

        /// <summary>
        /// Creates a MySqlParameter
        /// </summary>
        /// <param name="theValue">The value.</param>
        /// <param name="parameterName">The name of the parameter</param>
        /// <returns>The <see cref="MySqlParameter"/></returns>
        public static MySqlParameter CreateMySqlParameter(this decimal theValue, string parameterName)
        {
            return Factory.CreateParameter(theValue, parameterName);
        }

        /// <summary>
        /// Creates a MySqlParameter
        /// </summary>
        /// <param name="theValue">The value.</param>
        /// <param name="parameterName">The name of the parameter</param>
        /// <returns>The <see cref="MySqlParameter"/></returns>
        public static MySqlParameter CreateMySqlParameter(this bool theValue, string parameterName)
        {
            return Factory.CreateParameter(theValue, parameterName);
        }

        /// <summary>
        /// Creates a MySqlParameter
        /// </summary>
        /// <param name="theValue">The value.</param>
        /// <param name="parameterName">The name of the parameter</param>
        /// <param name="dateTimeType">Type of the SQL column.</param>
        /// <returns>
        /// The <see cref="MySqlParameter" />
        /// </returns>
        /// <exception cref="System.ArgumentNullException">parameterName</exception>
        public static MySqlParameter CreateMySqlParameter(this DateTime theValue, string parameterName, MySqlDbType dateTimeType)
        {
            MySqlParameter mySqlParameter = Factory.CreateParameter(theValue, parameterName);
            mySqlParameter.MySqlDbType = dateTimeType;
            return mySqlParameter;
        }

        /// <summary>
        /// Creates a MySqlParameter with either DBNull or a value
        /// </summary>
        /// <param name="theValue">The value.</param>
        /// <param name="parameterName">The name of the parameter</param>
        /// <returns>The <see cref="MySqlParameter"/></returns>
        public static MySqlParameter CreateMySqlParameter(this bool? theValue, string parameterName)
        {
            return Factory.CreateParameter(theValue, parameterName);
        }

        /// <summary>
        /// Creates a MySqlParameter with either DBNull or a value
        /// </summary>
        /// <param name="theValue">The value.</param>
        /// <param name="parameterName">The name of the parameter</param>
        /// <param name="dateTimeType">Type of the SQL column.</param>
        /// <returns>
        /// The <see cref="MySqlParameter" />
        /// </returns>
        /// <exception cref="System.ArgumentNullException">parameterName</exception>
        public static MySqlParameter CreateMySqlParameter(this DateTime? theValue, string parameterName, MySqlDbType dateTimeType)
        {
            if (theValue.HasValue)
            {
                CreateMySqlParameter(theValue.Value, parameterName, dateTimeType);
            }

            return Factory.CreateParameter(theValue, parameterName);
        }

        /// <summary>
        /// Creates a MySqlParameter with either DBNull or a value
        /// </summary>
        /// <param name="theValue">The value.</param>
        /// <param name="parameterName">The name of the parameter</param>
        /// <returns>The <see cref="MySqlParameter"/></returns>
        public static MySqlParameter CreateMySqlParameter(this long? theValue, string parameterName)
        {
            return Factory.CreateParameter(theValue, parameterName);
        }

        /// <summary>
        /// Creates a <see cref="MySqlParameter"/>.
        /// </summary>
        /// <param name="theValue">The value.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>The <see cref="MySqlParameter"/></returns>
        public static MySqlParameter CreateMySqlParameter(this long theValue, string parameterName)
        {
            return Factory.CreateParameter(theValue, parameterName);
        }

        /// <summary>
        /// Creates a MySqlParameter for a tinyint
        /// </summary>
        /// <param name="theValue">the value.</param>
        /// <param name="parameterName">The name of the parameter</param>
        /// <returns>The <see cref="MySqlParameter"/></returns>
        public static MySqlParameter CreateMySqlParameter(this byte theValue, string parameterName)
        {
            return Factory.CreateParameter(theValue, parameterName);
        }
    }
}