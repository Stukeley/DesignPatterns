﻿namespace DesignPatterns
{
	internal class Addendum
	{
		//! Main differences between 'abstract class' and 'interface'
		//! For more detailed info: https://stukeleyak.com/2020/09/26/interface-vs-abstract-class/

		// Interface:	 does not contain a constructor
		// Abstract class: CAN contain a constructor

		// Interface: does not contain static methods
		// Abstract class: CAN contain static methods

		// Interface: can only contain methods and properties
		// Abstract class: can ALSO contain fields, constants

		// Interface: a class can implement many interfaces
		// Abstract class: a class can only implement ONE other class
	}
}
