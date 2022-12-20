using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using EXTAttribute = System.Runtime.InteropServices.DllImportAttribute;
using System.Reflection;

namespace il2cpplib
{
    public static unsafe class Il2Cpp
    {
        const string GameAssembly = "GameAssembly.dll"; //const string GameAssembly = "UnityGame.dll" 

        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_init(IntPtr domain_name);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_init_utf16(IntPtr domain_name);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_shutdown();
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_set_config_dir(IntPtr config_path);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_set_data_dir(IntPtr data_path);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_set_temp_dir(IntPtr temp_path);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_set_commandline_arguments(int argc, IntPtr argv, IntPtr basedir);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_set_commandline_arguments_utf16(int argc, IntPtr argv, IntPtr basedir);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_set_config_utf16(IntPtr executablePath);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_set_config(IntPtr executablePath);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_set_memory_callbacks(IntPtr callbacks);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_get_corlib();
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_add_internal_call(IntPtr name, IntPtr method);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_resolve_icall([MarshalAs(UnmanagedType.LPStr)] string name);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_alloc(uint size);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_free(IntPtr ptr);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_array_class_get(IntPtr element_class, uint rank);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern uint il2cpp_array_length(IntPtr array);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern uint il2cpp_array_get_byte_length(IntPtr array);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_array_new(IntPtr elementTypeInfo, ulong length);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_array_new_specific(IntPtr arrayTypeInfo, ulong length);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_array_new_full(IntPtr array_class, ref ulong lengths, ref ulong lower_bounds);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_bounded_array_class_get(IntPtr element_class, uint rank, bool bounded);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int il2cpp_array_element_size(IntPtr array_class);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_assembly_get_image(IntPtr assembly);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_class_enum_basetype(IntPtr klass);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool il2cpp_class_is_generic(IntPtr klass);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool il2cpp_class_is_inflated(IntPtr klass);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool il2cpp_class_is_assignable_from(IntPtr klass, IntPtr oklass);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool il2cpp_class_is_subclass_of(IntPtr klass, IntPtr klassc, bool check_interfaces);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool il2cpp_class_has_parent(IntPtr klass, IntPtr klassc);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_class_from_il2cpp_type(IntPtr type);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_class_from_name(IntPtr image, [MarshalAs(UnmanagedType.LPStr)] string namespaze, [MarshalAs(UnmanagedType.LPStr)] string name);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_class_from_system_type(IntPtr type);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_class_get_element_class(IntPtr klass);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_class_get_events(IntPtr klass, ref IntPtr iter);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_class_get_fields(IntPtr klass, ref IntPtr iter);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_class_get_nested_types(IntPtr klass, ref IntPtr iter);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_class_get_interfaces(IntPtr klass, ref IntPtr iter);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_class_get_properties(IntPtr klass, ref IntPtr iter);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_class_get_property_from_name(IntPtr klass, [MarshalAs(UnmanagedType.LPStr)] string name);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_class_get_field_from_name(IntPtr klass, [MarshalAs(UnmanagedType.LPStr)] string name);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_class_get_methods(IntPtr klass, ref IntPtr iter);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_class_get_method_from_name(IntPtr klass, [MarshalAs(UnmanagedType.LPStr)] string name, int argsCount);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_class_get_name(IntPtr klass);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_class_get_namespace(IntPtr klass);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_class_get_parent(IntPtr klass);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_class_get_declaring_type(IntPtr klass);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int il2cpp_class_instance_size(IntPtr klass);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern uint il2cpp_class_num_fields(IntPtr enumKlass);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool il2cpp_class_is_valuetype(IntPtr klass);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int il2cpp_class_value_size(IntPtr klass, ref uint align);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool il2cpp_class_is_blittable(IntPtr klass);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int il2cpp_class_get_flags(IntPtr klass);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool il2cpp_class_is_abstract(IntPtr klass);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool il2cpp_class_is_interface(IntPtr klass);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int il2cpp_class_array_element_size(IntPtr klass);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_class_from_type(IntPtr type);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_class_get_type(IntPtr klass);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern uint il2cpp_class_get_type_token(IntPtr klass);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool il2cpp_class_has_attribute(IntPtr klass, IntPtr attr_class);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool il2cpp_class_has_references(IntPtr klass);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool il2cpp_class_is_enum(IntPtr klass);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_class_get_image(IntPtr klass);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_class_get_assemblyname(IntPtr klass);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int il2cpp_class_get_rank(IntPtr klass);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern uint il2cpp_class_get_bitmap_size(IntPtr klass);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_class_get_bitmap(IntPtr klass, ref uint bitmap);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_get_meta_data_pool_memory();
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool il2cpp_stats_dump_to_file(IntPtr path);

        //[Il2cpp(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi]
        //public extern static ulong il2cpp_stats_get_value(IL2CPP_Stat stat);

        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_domain_get();
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_domain_assembly_open(IntPtr domain, IntPtr name);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr* il2cpp_domain_get_assemblies(IntPtr domain, ref uint size);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_exception_from_name_msg(IntPtr image, IntPtr name_space, IntPtr name, IntPtr msg);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_get_exception_argument_null(IntPtr arg);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_format_exception(IntPtr ex, void* message, int message_size);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_format_stack_trace(IntPtr ex, void* output, int output_size);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_unhandled_exception(IntPtr ex);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int il2cpp_field_get_flags(IntPtr field);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_field_get_name(IntPtr field);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_field_get_parent(IntPtr field);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern uint il2cpp_field_get_offset(IntPtr field);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_field_get_type(IntPtr field);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_field_get_value(IntPtr obj, IntPtr field, void* value);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_field_get_value_object(IntPtr field, IntPtr obj);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool il2cpp_field_has_attribute(IntPtr field, IntPtr attr_class);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_field_set_value(IntPtr obj, IntPtr field, void* value);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_field_static_get_value(IntPtr field, void* value);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_field_static_set_value(IntPtr field, void* value);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_field_set_value_object(IntPtr instance, IntPtr field, IntPtr value);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_gc_collect(int maxGenerations);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int il2cpp_gc_collect_a_little();
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_gc_disable();
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_gc_enable();
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool il2cpp_gc_is_disabled();
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern long il2cpp_gc_get_used_size();
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern long il2cpp_gc_get_heap_size();
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_gc_wbarrier_set_field(IntPtr obj, out IntPtr targetAddress, IntPtr gcObj);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern uint il2cpp_gchandle_new(IntPtr obj, bool pinned);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern uint il2cpp_gchandle_new_weakref(IntPtr obj, bool track_resurrection);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_gchandle_get_target(uint gchandle);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_gchandle_free(uint gchandle);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_unity_liveness_calculation_begin(IntPtr filter, int max_object_count, IntPtr callback, IntPtr userdata, IntPtr onWorldStarted, IntPtr onWorldStopped);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_unity_liveness_calculation_end(IntPtr state);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_unity_liveness_calculation_from_root(IntPtr root, IntPtr state);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_unity_liveness_calculation_from_statics(IntPtr state);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_method_get_return_type(IntPtr method);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_method_get_declaring_type(IntPtr method);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_method_get_name(IntPtr method);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_method_get_from_reflection(IntPtr method);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_method_get_object(IntPtr method, IntPtr refclass);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool il2cpp_method_is_generic(IntPtr method);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool il2cpp_method_is_inflated(IntPtr method);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool il2cpp_method_is_instance(IntPtr method);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern uint il2cpp_method_get_param_count(IntPtr method);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_method_get_param(IntPtr method, uint index);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_method_get_class(IntPtr method);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool il2cpp_method_has_attribute(IntPtr method, IntPtr attr_class);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern uint il2cpp_method_get_flags(IntPtr method, ref uint iflags);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern uint il2cpp_method_get_token(IntPtr method);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_method_get_param_name(IntPtr method, uint index);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_profiler_install(IntPtr prof, IntPtr shutdown_callback);

        //[Il2cpp(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ans)] 
        //public extern static void il2cpp_profiler_set_events(IL2CPP_ProfileFlags events);

        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_profiler_install_enter_leave(IntPtr enter, IntPtr fleave);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_profiler_install_allocation(IntPtr callback);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_profiler_install_gc(IntPtr callback, IntPtr heap_resize_callback);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_profiler_install_fileio(IntPtr callback);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_profiler_install_thread(IntPtr start, IntPtr end);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern uint il2cpp_property_get_flags(IntPtr prop);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_property_get_get_method(IntPtr prop);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_property_get_set_method(IntPtr prop);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_property_get_name(IntPtr prop);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_property_get_parent(IntPtr prop);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_object_get_class(IntPtr obj);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern uint il2cpp_object_get_size(IntPtr obj);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_object_get_virtual_method(IntPtr obj, IntPtr method);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_object_new(IntPtr klass);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_object_unbox(IntPtr obj);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_value_box(IntPtr klass, IntPtr data);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_monitor_enter(IntPtr obj);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool il2cpp_monitor_try_enter(IntPtr obj, uint timeout);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_monitor_exit(IntPtr obj);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_monitor_pulse(IntPtr obj);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_monitor_pulse_all(IntPtr obj);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_monitor_wait(IntPtr obj);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool il2cpp_monitor_try_wait(IntPtr obj, uint timeout);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern unsafe IntPtr il2cpp_runtime_invoke(IntPtr method, IntPtr obj, void** param, ref IntPtr exc);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern unsafe IntPtr il2cpp_runtime_invoke_convert_args(IntPtr method, IntPtr obj, void** param, int paramCount, ref IntPtr exc);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_runtime_class_init(IntPtr klass);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_runtime_object_init(IntPtr obj);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_runtime_object_init_exception(IntPtr obj, ref IntPtr exc);


        // [Il2cpp(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ans)]
        // public extern static void il2cpp_runtime_unhandled_exception_policy_set(IL2CPP_RuntimeUnhandledExceptionPolicy value);

        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int il2cpp_string_length(IntPtr str);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern unsafe char* il2cpp_string_chars(IntPtr str);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_string_new(string str);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_string_new_len(string str, uint length);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_string_new_utf16(char* text, int len);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_string_new_wrapper(string str);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_string_intern(string str);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_string_is_interned(string str);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_thread_current();
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_thread_attach(IntPtr domain);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_thread_detach(IntPtr thread);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern unsafe void** il2cpp_thread_get_all_attached_threads(ref uint size);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool il2cpp_is_vm_thread(IntPtr thread);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_current_thread_walk_frame_stack(IntPtr func, IntPtr user_data);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_thread_walk_frame_stack(IntPtr thread, IntPtr func, IntPtr user_data);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool il2cpp_current_thread_get_top_frame(IntPtr frame);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool il2cpp_thread_get_top_frame(IntPtr thread, IntPtr frame);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool il2cpp_current_thread_get_frame_at(int offset, IntPtr frame);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool il2cpp_thread_get_frame_at(IntPtr thread, int offset, IntPtr frame);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int il2cpp_current_thread_get_stack_depth();
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int il2cpp_thread_get_stack_depth(IntPtr thread);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_type_get_object(IntPtr type);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int il2cpp_type_get_type(IntPtr type);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_type_get_class_or_element_class(IntPtr type);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_type_get_name(IntPtr type);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool il2cpp_type_is_byref(IntPtr type);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern uint il2cpp_type_get_attrs(IntPtr type);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool il2cpp_type_equals(IntPtr type, IntPtr otherType);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_type_get_assembly_qualified_name(IntPtr type);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_image_get_assembly(IntPtr image);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_image_get_name(IntPtr image);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_image_get_filename(IntPtr image);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_image_get_entry_point(IntPtr image);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern uint il2cpp_image_get_class_count(IntPtr image);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_image_get_class(IntPtr image, uint index);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_capture_memory_snapshot();
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_free_captured_memory_snapshot(IntPtr snapshot);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_set_find_plugin_callback(IntPtr method);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_register_log_callback(IntPtr method);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_debugger_set_agent_options(IntPtr options);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool il2cpp_is_debugger_attached();
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern unsafe void il2cpp_unity_install_unitytls_interface(void* unitytlsInterfaceStruct);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_custom_attrs_from_class(IntPtr klass);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_custom_attrs_from_method(IntPtr method);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_custom_attrs_get_attr(IntPtr ainfo, IntPtr attr_klass);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool il2cpp_custom_attrs_has_attr(IntPtr ainfo, IntPtr attr_klass);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr il2cpp_custom_attrs_construct(IntPtr cinfo);
        [EXT(GameAssembly, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void il2cpp_custom_attrs_free(IntPtr ainfo);
    }
}
