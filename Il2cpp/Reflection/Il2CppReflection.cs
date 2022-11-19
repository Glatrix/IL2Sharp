using CodeInject.Il2cpp.VM;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using static il2cpplib.Il2Cpp;

namespace il2cpplib
{
    /// <summary> ~ UnityEngine.Application</summary>
    public static class Application
    {
        private const string _GetUnityVersion = "UnityEngine.Application::get_unityVersion()";
        private static GetObject GetUnityVersion;

        public static string UnityVersion => StringUtils.ReadSystemString(GetUnityVersion());

        static Application()
        {
            IntPtr GetUnityVersion_call = il2cpp_resolve_icall(_GetUnityVersion);
            GetUnityVersion = Marshal.GetDelegateForFunctionPointer<GetObject>(GetUnityVersion_call);
        }
    }


    /// <summary> ~ Il2cpp Domain</summary>
    public class Domain : Il2cppObjectBase
    {

        /// <summary> ~ Gets the current il2cpp domain</summary>
        public static Domain CurrentDomain
            => new Domain { Address = il2cpp_domain_get() };

        /// <summary> ~ Gets a list of all assemblies in current domain</summary>
        public unsafe List<Assembly> GetAssemblies()
        {
            List<Assembly> temp = new List<Assembly>();
            if (Address != IntPtr.Zero)
            {
                uint count = 0;
                IntPtr* assemblies = il2cpp_domain_get_assemblies(Address, ref count);
                for (int i = 0; i < count; i++)
                    temp.Add(new Assembly() { Address = assemblies[i] });
            }
            return temp;
        }

        /// <summary> ~ Gets an assembly by name</summary>
        public Assembly OpenAssembly(string name)
        {
            IntPtr _name = il2cpp_string_new(name);
            IntPtr _assembly = il2cpp_domain_assembly_open(Address, _name);

            if (_assembly == IntPtr.Zero)
            {
                return GetAssemblies().Find((x) => x.Image.Name == name || x.Image.Filename == name);
            }
            
                
            return new Assembly() { Address = _assembly };
        }

    }

    /// <summary> ~ Il2cpp Assembly</summary>
    public class Assembly : Il2cppObjectBase
    {
        /// <summary> ~ All Image info of assembly</summary>
        public Image Image => new Image() { Address = il2cpp_assembly_get_image(Address) };

    }

    /// <summary> ~ Il2cpp Image</summary>
    public class Image : Il2cppObjectBase
    {
        /// <summary> ~ Parent Assembly</summary>
        public Assembly Assembly => new Assembly() { Address = il2cpp_image_get_assembly(Address) };

        /// <summary> ~ Name of Current Image</summary>
        public string Name => StringUtils.ReadString(il2cpp_image_get_name(Address));

        /// <summary> ~ FileName of Current Image (Not On Disk)</summary>
        public string Filename => StringUtils.ReadString(il2cpp_image_get_filename(Address));

        /// <summary> ~ Number of classes belonging to current Image</summary>
        public uint ClassCount => il2cpp_image_get_class_count(Address);

        /// <summary> ~ Entry Point of Image [No Information]</summary>
        public IntPtr EntryPoint => il2cpp_image_get_entry_point(Address);

        /// <summary> ~ Get Class from Image by Index</summary>
        public Class GetClass(int index)
        {
            IntPtr @class = il2cpp_image_get_class(Address, (uint)index);
            if (@class != IntPtr.Zero)
            {
                return new Class() { Address = @class };
            }
            return null;
        }

        public Class OpenClass(string name)
        {
            return Classes.Find((m) => m.Name == name);
        }


        /// <summary> ~ Get All Classes from Image</summary>
        public List<Class> Classes
        {
            get
            {
                List<Class> temp = new List<Class>();
                if (Address != IntPtr.Zero)
                {
                    int classCount = (int)il2cpp_image_get_class_count(Address);
                    for (int i = 0; i < classCount; i++)
                    {
                        temp.Add(new Class() { Address = il2cpp_image_get_class(Address, (uint)i) });
                    }
                }
                return temp;
            }
        }
    }

    /// <summary> ~ Il2cpp Class</summary>
    public class Class : Il2cppObjectBase
    {
        /// <summary> ~ Get Class From Type</summary>
        public static Class GetFromType(Type @type) => new Class() { Address = il2cpp_class_from_il2cpp_type(@type.Address) };
        /// <summary> ~ Get Class From System Type</summary>
        public static Class GetFromSystemType(Type sysType) => new Class() { Address = il2cpp_class_from_system_type(sysType.Address) };
        /// <summary> ~ Resolve a Class from some basic Class Information</summary>
        public static Class Resolve(Image image, string @namespace, string @classname)
        {
            return new Class() { Address = il2cpp_class_from_name(image.Address, @namespace, @classname) };
        }
        /// <summary> ~ Class Flags</summary>
        public TypeAttributes Flags => (TypeAttributes)il2cpp_class_get_flags(Address);
        /// <summary> ~ Class Name</summary>
        public string Name => StringUtils.ReadString(il2cpp_class_get_name(Address));
        /// <summary> ~ Class Namespace</summary>
        public string Namespace => StringUtils.ReadString(il2cpp_class_get_namespace(Address));
        /// <summary> ~ Class Assembly Name</summary>
        public string AssemblyName => StringUtils.ReadString(il2cpp_class_get_assemblyname(Address));
        /// <summary> ~ Is Generic Class</summary>
        public bool IsGeneric => il2cpp_class_is_generic(Address);
        /// <summary> ~  Is Inflated Class</summary>
        public bool IsInflated => il2cpp_class_is_inflated(Address);
        /// <summary> ~  Is Abstract Class</summary>
        public bool IsAbstract => il2cpp_class_is_abstract(Address);
        /// <summary> ~  Is Interface Class</summary>
        public bool IsInterface => il2cpp_class_is_interface(Address);
        /// <summary> ~  Is Enum Class</summary>
        public bool IsEnum => il2cpp_class_is_enum(Address);
        /// <summary> ~  Class Has References</summary>
        public bool HasReferences => il2cpp_class_has_references(Address);
        /// <summary> ~  Is Class a Value Type</summary>
        public bool IsValueType => il2cpp_class_is_valuetype(Address);
        /// <summary> ~  Is Blittable Class</summary>
        public bool IsBlittable => il2cpp_class_is_blittable(Address);
        /// <summary> ~  Check if Class is assignable from another Class</summary>
        public bool AssignableFrom(Class @class) => il2cpp_class_is_assignable_from(Address, @class.Address);
        /// <summary> ~  Check if Class is assignable from another Class</summary>
        public bool AssignableFrom(IntPtr @class) => il2cpp_class_is_assignable_from(Address, @class);

        /// <summary> ~  Check if Class is a Subclass of another Class</summary>
        public bool IsSubclassOf(Class @class, bool checkInterfaces) => il2cpp_class_is_subclass_of(Address, @class.Address, checkInterfaces);
        /// <summary> ~  Check if Class is a Subclass of another Class</summary>
        public bool IsSubclassOf(IntPtr @class, bool checkInterfaces) => il2cpp_class_is_subclass_of(Address, @class, checkInterfaces);
        /// <summary> ~  Check if Class has a specific Attribute</summary>
        public bool HasAttribute(Class attr_class) => il2cpp_class_has_attribute(Address, attr_class.Address);
        /// <summary> ~  Check if Class has a specific Attribute</summary>
        public bool HasAttribute(IntPtr attr_class) => il2cpp_class_has_attribute(Address, attr_class);
        /// <summary> ~  Check if Class has a specific Parent</summary>
        public bool HasParent(Class parent) => il2cpp_class_has_parent(Address, parent.Address);
        /// <summary> ~  Check if Class has a specific Parent</summary>
        public bool HasParent(IntPtr parent) => il2cpp_class_has_parent(Address, parent);
        /// <summary> ~  Size of a given Instance of this Class</summary>
        public int InstanceSize => il2cpp_class_instance_size(Address);
        /// <summary> ~ Count of Fields in Class</summary>
        public int FieldCount => (int)il2cpp_class_num_fields(Address);
        /// <summary> ~ [No Information Abaliable]</summary>
        public int ArrayElementSize => il2cpp_class_array_element_size(Address);
        /// <summary> ~ the Rank of the Class</summary>
        public int Rank => il2cpp_class_get_rank(Address);
        /// <summary> ~ the Value Size of the Class</summary>
        public int ValueSize(ref uint align) => il2cpp_class_value_size(Address, ref align);
        /// <summary> ~ The Class's Type's Token</summary>
        public uint TypeToken => il2cpp_class_get_type_token(Address);
        /// <summary> ~ The Size of the Class's Bitmap</summary>
        public uint BitmapSize => il2cpp_class_get_bitmap_size(Address);
        /// <summary> ~ Gets the Class's Bitmap</summary>
        public void GetBitmap(ref uint bitmap) { il2cpp_class_get_bitmap(Address, ref bitmap); }
        /// <summary> ~ Gets the Class's Parent Image</summary>
        public Image Image => new Image() { Address = il2cpp_class_get_image(Address) };
        /// <summary> ~ Gets the Class's Parent Class</summary>
        public Class Parent => new Class() { Address = il2cpp_class_get_parent(Address) };
        /// <summary> ~ Gets the Class's Element Class</summary>
        public Class ElementClass => new Class() { Address = il2cpp_class_get_element_class(Address) };
        /// <summary> ~ Gets the Class's Declaring Type</summary>
        public Type DeclaringType => new Type() { Address = il2cpp_class_get_declaring_type(Address) };
        /// <summary> ~ Gets the Class's Enum Base Type</summary>
        public Type EnumBaseType => new Type() { Address = il2cpp_class_enum_basetype(Address) };
        /// <summary> ~ Gets the Class's Type</summary>
        public Type Type => new Type() { Address = il2cpp_class_get_type(Address) };
        /// <summary> ~ Gets a Property by Name</summary>
        public Property GetPropertyFromName(string name) => new Property() { Address = il2cpp_class_get_property_from_name(Address, name) };
        /// <summary> ~ Gets a Method by Name and Parameter Count</summary>
        public Method GetMethodFromName(string name, int paramaterCount) => new Method() { Address = il2cpp_class_get_method_from_name(Address, name, paramaterCount) };

        /// <summary> ~ Gets a Method by Name</summary>
        public Method GetMethodByName(string name)
        {
            foreach(var m in Methods)
            {
                if(m.Name == name) 
                    return m;
            }
            return null;
        }

        /// <summary> ~ Gets a Field by Name</summary>
        public Field GetFieldFromName(string name) => new Field() { Address = il2cpp_class_get_field_from_name(Address, name) };



        /// <summary> ~ List of the Class's Events</summary>
        public IntPtr Events
        {
            get
            {
                List<IntPtr> temp = new List<IntPtr>();
                IntPtr iter = IntPtr.Zero;
                IntPtr Event;

                return il2cpp_class_get_events(Address, ref iter);
            }
        }
        /// <summary> ~ List of the Class's Fields</summary>
        public List<Field> Fields
        {
            get
            {
                List<Field> temp = new List<Field>();
                IntPtr iter = IntPtr.Zero;
                IntPtr Field;

                while ((Field = il2cpp_class_get_fields(Address, ref iter)) != IntPtr.Zero)
                { temp.Add(new Field() { Address = Field }); }

                return temp;
            }
        }
        /// <summary> ~ List of the Class's Nested Types</summary>
        public List<Type> NestedTypes
        {
            get
            {
                List<Type> temp = new List<Type>();
                IntPtr iter = IntPtr.Zero;
                IntPtr Type;

                while ((Type = il2cpp_class_get_nested_types(Address, ref iter)) != IntPtr.Zero)
                { temp.Add(new Type() { Address = Type }); }

                return temp;
            }
        }
        /// <summary> ~ List of the Class's Interfaces</summary>
        public List<Class> Interfaces
        {
            get
            {
                List<Class> temp = new List<Class>();
                IntPtr iter = IntPtr.Zero;
                IntPtr Interface;

                while ((Interface = il2cpp_class_get_interfaces(Address, ref iter)) != IntPtr.Zero)
                { temp.Add(new Class() { Address = Interface }); }

                return temp;
            }
        }
        /// <summary> ~ List of the Class's Properties</summary>
        public List<Property> Properties
        {
            get
            {
                List<Property> temp = new List<Property>();
                IntPtr iter = IntPtr.Zero;
                IntPtr Property;

                while ((Property = il2cpp_class_get_properties(Address, ref iter)) != IntPtr.Zero)
                { temp.Add(new Property() { Address = Property }); }

                return temp;
            }
        }
        /// <summary> ~ List of the Class's Methods</summary>
        public List<Method> Methods
        {
            get
            {
                List<Method> temp = new List<Method>();
                IntPtr iter = IntPtr.Zero;
                IntPtr Method;

                while ((Method = il2cpp_class_get_methods(Address, ref iter)) != IntPtr.Zero)
                { temp.Add(new Method() { Address = Method }); }

                return temp;
            }
        }
    }

    /// <summary> ~ Il2cpp Type</summary>
    public class Type : Il2cppObjectBase
    {
        /// <summary> ~ The Type's Object</summary>
        public IntPtr Object => il2cpp_type_get_object(Address);
        /// <summary> ~ The Qualified Name of the Parent Assembly</summary>
        public string AssemblyQualifiedName => StringUtils.ReadString(il2cpp_type_get_assembly_qualified_name(Address));
        /// <summary> ~ The Type's Name</summary>
        public string Name => StringUtils.ReadString(il2cpp_type_get_name(Address));
        /// <summary> ~ Type Kind</summary>
        public Il2CppTypes TypeKind => (Il2CppTypes)il2cpp_type_get_type(Address);
        /// <summary> ~ The Type's Attributes</summary>
        public TypeAttributes Attributes => (TypeAttributes)il2cpp_type_get_attrs(Address);
        /// <summary> ~ Is Type ByRef?</summary>
        public bool IsByRef => il2cpp_type_is_byref(Address);
        /// <summary> ~ Compare to Other Type (Does not override Equals)</summary>
        public bool EqualTo(Type t) => il2cpp_type_equals(Address, t.Address);
        /// <summary> ~ The Class (or element class) of the Type</summary>
        public Class ClassOrElementClass => new Class() { Address = il2cpp_type_get_class_or_element_class(Address) };
    }

    /// <summary> ~ Il2cpp Property</summary>
    public class Property : Il2cppObjectBase
    {
        /// <summary> ~ The Property's Attributes</summary>
        public PropertyAttributes Attributes => (PropertyAttributes)il2cpp_property_get_flags(Address);
        /// <summary> ~ The "get { }" Method </summary>
        public Method Getter => new Method() { Address = il2cpp_property_get_get_method(Address) };
        /// <summary> ~ The "set { }" Method </summary>
        public Method Setter => new Method() { Address = il2cpp_property_get_set_method(Address) };
        /// <summary> ~ The Parent Type </summary>
        public Type Parent => new Type() { Address = il2cpp_property_get_parent(Address) };
        /// <summary> ~ The Property Name </summary>
        public string Name => StringUtils.ReadString(il2cpp_property_get_name(Address));
    }

    /// <summary> ~ Il2cpp Field </summary>
    public class Field : Il2cppObjectBase
    {
        /// <summary> ~ The Field's Attributes </summary>
        public FieldAttributes Attributes => (FieldAttributes)il2cpp_field_get_flags(Address);
        /// <summary> ~ The Field's Parent Type </summary>
        public Type Parent => new Type() { Address = il2cpp_field_get_parent(Address) };
        /// <summary> ~ The Field's Type (typeof Instance) </summary>
        public Type Type => new Type() { Address = il2cpp_field_get_type(Address) };
        /// <summary> ~ The Field's Name </summary>
        public string Name => StringUtils.ReadString(il2cpp_field_get_name(Address));
        /// <summary> ~ The Field's Offset in Memory </summary>
        public int Offset => (int)il2cpp_field_get_offset(Address);
        /// <summary> ~ Check if Field has an Attribute </summary>
        public bool HasAttribute(Class attr_class) => il2cpp_field_has_attribute(Address, attr_class.Address);
        /// <summary> ~ Get Static Value of Field (Only applicable if Field is Static) </summary>
        public unsafe T GetStatic<T>() where T : unmanaged
        {
            T t = new T();
            il2cpp_field_static_get_value(Address, (void*)&t);
            return t;
        }

        /// <summary> ~ Set Static Value of Field (Only applicable if field is Static) </summary>
        public unsafe void SetStatic<T>(T t) where T : unmanaged
        {
            il2cpp_field_static_set_value(Address, &t);
        }

        // ----- Still thinking of the best way to impliment these -----
        // - public static extern void il2cpp_field_get_value(IntPtr obj, IntPtr field, void* value);
        // - public static extern IntPtr il2cpp_field_get_value_object(IntPtr field, IntPtr obj);
        // - public static extern void il2cpp_field_set_value(IntPtr obj, IntPtr field, void* value);
        // - public static extern void il2cpp_field_set_value_object(IntPtr instance, IntPtr field, IntPtr value);
    }

    /// <summary> ~ Il2cpp Method </summary>
    public class Method : Il2cppObjectBase
    {
        public unsafe IntPtr ObjectInvoke(IntPtr obj, params object[] @params)
        {
            IntPtr* numPtr = stackalloc IntPtr[@params.Length];

            for(int i = 0; i < @params.Length; i++)
            {
                if (@params[i] is int)
                {
                    int integer = (int)@params[i];
                    numPtr[i] = (IntPtr)(&integer);
                }
                else if (@params[i] is bool)
                {
                    bool boolean = (bool)@params[i];
                    numPtr[i] = (IntPtr)(&boolean);
                }
                else if(@params[i] is string)
                {
                    string str = (string)@params[i];
                    numPtr[i] = StringUtils.StrToSys_Str(str);
                }
            }

            IntPtr exc = IntPtr.Zero;
            IntPtr ret = Il2Cpp.il2cpp_runtime_invoke(Address, obj, (void**)numPtr, ref exc);
            Il2CppException.HandlePossibleException(exc);
            return ret;
        }


        public MethodAttributes Attributes
        {
            get
            { uint iflags = 0u; return (MethodAttributes)il2cpp_method_get_flags(Address, ref iflags); }
        }
        public MethodImplAttributes ImplAttributes
        {
            get
            { uint iflags = 0u; il2cpp_method_get_flags(Address, ref iflags); return (MethodImplAttributes)iflags; }
        }

        /// <summary> ~ Parent Class </summary>
        public Class Class => new Class() { Address = il2cpp_method_get_class(Address) };
        /// <summary> ~ Method Ret Type </summary>
        public Type ReturnType => new Type() { Address = il2cpp_method_get_return_type(Address) };
        /// <summary> ~ Method Decl Type </summary>
        public Type DeclaringType => new Type() { Address = il2cpp_method_get_declaring_type(Address) };

        /// <summary> ~ Get Parameter by Index </summary>
        public Parameter GetParameter(uint index)
            => new Parameter(this, index) { Address = il2cpp_method_get_param(Address, index) };

        public string Name => StringUtils.ReadString(il2cpp_method_get_name(Address));
        /// <summary> ~ The Method's Name </summary>
        public int Token => (int)il2cpp_method_get_token(Address);
        /// <summary> ~ The Token of the Method </summary>
        public int ParamCount => (int)il2cpp_method_get_param_count(Address);
        /// <summary> ~ Count of Method's Parameters </summary>
        public bool IsGeneric => il2cpp_method_is_generic(Address);
        /// <summary> ~ Checks if Method Is Generic </summary>
        public bool IsInflated => il2cpp_method_is_inflated(Address);

        /// <summary> ~ Checks if Method Is Instance </summary>
        public bool IsInstance => il2cpp_method_is_instance(Address);

        /// <summary> ~ Checks if Method has Attribute </summary>
        public bool HasAttribute(Class attr_class) => il2cpp_method_has_attribute(Address, attr_class.Address);

        /// <summary> ~ List of Method's Parameters </summary>
        public List<Parameter> Parameters
        {
            get
            {
                List<Parameter> temp = new List<Parameter>();
                for (uint i = 0; i < ParamCount; i++)
                {
                    temp.Add(GetParameter(i));
                }
                return temp;
            }
        }

        public string CppSignature { 
            get
            {
                string sig = $"{Class.Name}::{Name}" +
                    $"({string.Join(",", Parameters.Select((p) => $"{p.Type.Name}"))})";

                string namespaze = Class.Namespace;

                if (!string.IsNullOrWhiteSpace(namespaze))
                {
                    return $"{namespaze}.{sig}";
                }
                return $"UnityEngine.{sig}";
            } 
        }

        public string CSSignature
        {
            get
            {
                string parameters = string.Join(",", Parameters.Select((p) => $"{p.Type.Name} {p.Name}"));

                if (!Attributes.HasFlag(MethodAttributes.Static))
                {
                    if (parameters == "")
                        parameters = "Il2CppBase obj";
                    else
                        parameters = $"Il2CppBase obj, {parameters}";
                }


                string sig = $"{Class.Name}_{Name}" +
                    $"({parameters})";

                string namespaze = Class.Namespace;

                if (!string.IsNullOrWhiteSpace(namespaze))
                {
                    return $"{ReturnType.Name} {namespaze}_{sig}";
                }
                return $"{ReturnType.Name} UnityEngine::{sig}";
            }
        }

        // ----- Still thinking of the best way to impliment these -----
        //public static extern IntPtr il2cpp_method_get_from_reflection(IntPtr method);
        //public static extern IntPtr il2cpp_method_get_object(IntPtr method, IntPtr refclass);
    }


    /// <summary> ~ Il2cpp Parameter (For Methods) </summary>
    public class Parameter : Il2cppObjectBase
    {
        private Method Method { get; set; } // ~ Parent Method of Parameter
        private uint Index { get; set; } // ~ Index of Parameter in the Parent Method's Parameters Array

        /// <summary> Constructor [Necessary Parameters] </summary>
        public Parameter(Method method, uint index) { Method = method; Index = index; } // [Requires Method and Index]
        public Class Class => new Class() { Address = il2cpp_class_from_type(Address) };
        public Type Type => new Type() { Address = Address };
        public string Name => StringUtils.ReadString(il2cpp_method_get_param_name(Method.Address, (uint)Index));
    }

}



