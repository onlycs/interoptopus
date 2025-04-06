// Automatically generated by Interoptopus.

#pragma warning disable 0105
using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Runtime.CompilerServices;
using My.Company;
#pragma warning restore 0105

namespace My.Company
{
    public static partial class Interop
    {
        public const string NativeLib = "library";

        static Interop()
        {
        }



        /// Function using the type.
        [LibraryImport(NativeLib, EntryPoint = "my_function")]
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static partial Vec2 my_function(Vec2 input);


    }

    /// A simple type in our FFI layer.
    public partial struct Vec2
    {
        public float x;
        public float y;
    }

    [NativeMarshalling(typeof(MarshallerMeta))]
    public partial struct Vec2 
    {
        public Vec2() { }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        internal unsafe Unmanaged ToUnmanaged()
        {
            var _unmanaged = new Unmanaged();
            _unmanaged.x = x;
            _unmanaged.y = y;
            return _unmanaged;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        internal unsafe Unmanaged AsUnmanaged()
        {
            var _unmanaged = new Unmanaged();
            _unmanaged.x = x;
            _unmanaged.y = y;
            return _unmanaged;
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct Unmanaged
        {
            public float x;
            public float y;

            [MethodImpl(MethodImplOptions.AggressiveOptimization)]
            internal unsafe Vec2 ToManaged()
            {
                var _managed = new Vec2();
                _managed.x = x;
                _managed.y = y;
                return _managed;
            }
        }


        [CustomMarshaller(typeof(Vec2), MarshalMode.Default, typeof(Marshaller))]
        private struct MarshallerMeta { }
        public ref struct Marshaller
        {
            private Vec2 _managed;
            private Unmanaged _unmanaged;

            [MethodImpl(MethodImplOptions.AggressiveOptimization)]
            public Marshaller(Vec2 managed) { _managed = managed; }

            [MethodImpl(MethodImplOptions.AggressiveOptimization)]
            public Marshaller(Unmanaged unmanaged) { _unmanaged = unmanaged; }

            [MethodImpl(MethodImplOptions.AggressiveOptimization)]
            public void FromManaged(Vec2 managed) { _managed = managed; }

            [MethodImpl(MethodImplOptions.AggressiveOptimization)]
            public void FromUnmanaged(Unmanaged unmanaged) { _unmanaged = unmanaged; }

            [MethodImpl(MethodImplOptions.AggressiveOptimization)]
            public Unmanaged ToUnmanaged() { return _managed.ToUnmanaged(); }

            [MethodImpl(MethodImplOptions.AggressiveOptimization)]
            public Vec2 ToManaged() { return _unmanaged.ToManaged(); }

            [MethodImpl(MethodImplOptions.AggressiveOptimization)]
            public void Free() { }
        }

    }



    public class InteropException: Exception
    {

        public InteropException(): base()
        {
        }
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void AsyncHelperNative(IntPtr data, IntPtr callback_data);
    public delegate void AsyncHelperDelegate(IntPtr data);

    public partial struct AsyncHelper
    {
        private AsyncHelperDelegate _managed;
        private AsyncHelperNative _native;
        private IntPtr _ptr;
    }

    [NativeMarshalling(typeof(MarshallerMeta))]
    public partial struct AsyncHelper : IDisposable
    {
        public AsyncHelper() { }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public AsyncHelper(AsyncHelperDelegate managed)
        {
            _managed = managed;
            _native = Call;
            _ptr = Marshal.GetFunctionPointerForDelegate(_native);
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        void Call(IntPtr data, IntPtr _)
        {
            _managed(data);
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public void Dispose()
        {
            if (_ptr == IntPtr.Zero) return;
            Marshal.FreeHGlobal(_ptr);
            _ptr = IntPtr.Zero;
        }

        [CustomMarshaller(typeof(AsyncHelper), MarshalMode.Default, typeof(Marshaller))]
        private struct MarshallerMeta { }

        [StructLayout(LayoutKind.Sequential)]
        public struct Unmanaged
        {
            internal IntPtr Callback;
            internal IntPtr Data;
        }

        public ref struct Marshaller
        {
            private AsyncHelper _managed;
            private Unmanaged _unmanaged;

            [MethodImpl(MethodImplOptions.AggressiveOptimization)]
            public void FromManaged(AsyncHelper managed) { _managed = managed; }
            [MethodImpl(MethodImplOptions.AggressiveOptimization)]
            public void FromUnmanaged(Unmanaged unmanaged) { _unmanaged = unmanaged; }

            [MethodImpl(MethodImplOptions.AggressiveOptimization)]
            public Unmanaged ToUnmanaged()
            {
                _unmanaged = new Unmanaged();
                _unmanaged.Callback = _managed._ptr;
                _unmanaged.Data = IntPtr.Zero;
                return _unmanaged;
            }

            [MethodImpl(MethodImplOptions.AggressiveOptimization)]
            public AsyncHelper ToManaged()
            {
                _managed = new AsyncHelper();
                _managed._ptr = _unmanaged.Callback;
                return _managed;
            }

            [MethodImpl(MethodImplOptions.AggressiveOptimization)]
            public void Free() { }
        }
    }
        public delegate void AsyncCallbackCommon(IntPtr data, IntPtr callback_data);

        [StructLayout(LayoutKind.Sequential)]
        public partial struct AsyncCallbackCommonNative
        {
            internal IntPtr _ptr;
            internal IntPtr _ts;
        }
        public partial class Utf8String
        {
            IntPtr _ptr;
            ulong _len;
            ulong _capacity;
        }

        [NativeMarshalling(typeof(MarshallerMeta))]
        public partial class Utf8String: IDisposable
        {
            private Utf8String() { }

            [MethodImpl(MethodImplOptions.AggressiveOptimization)]
            public static unsafe Utf8String From(string s)
            {
                var rval = new Utf8String();
                var source = s.AsSpan();
                Span<byte> utf8Bytes = stackalloc byte[Encoding.UTF8.GetByteCount(source)];
                var len = Encoding.UTF8.GetBytes(source, utf8Bytes);

                fixed (byte* p = utf8Bytes)
                {
                    InteropHelper.interoptopus_string_create((IntPtr) p, (ulong)len, out var native);
                    rval._ptr = native._ptr;
                    rval._len = native._len;
                    rval._capacity = native._capacity;
                }

                return rval;
            }

            [MethodImpl(MethodImplOptions.AggressiveOptimization)]
            public static unsafe Utf8String Empty()
            {
                InteropHelper.interoptopus_string_create(IntPtr.Zero, 0, out var _out);
                return _out.IntoManaged();
            }


            public unsafe string String
            {
                get
                {
                    var span = new ReadOnlySpan<byte>((byte*) _ptr, (int)_len);
                    var s = Encoding.UTF8.GetString(span);
                    return s;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveOptimization)]
            public string IntoString()
            {
                var rval = String;
                Dispose();
                return rval;
            }

            [MethodImpl(MethodImplOptions.AggressiveOptimization)]
            public void Dispose()
            {
                if (_ptr == IntPtr.Zero) return;
                var _unmanaged = new Unmanaged();
                _unmanaged._ptr = _ptr;
                _unmanaged._len = _len;
                _unmanaged._capacity = _capacity;
                InteropHelper.interoptopus_string_destroy(_unmanaged);
                _ptr = IntPtr.Zero;
            }

            [MethodImpl(MethodImplOptions.AggressiveOptimization)]
            public Utf8String Clone()
            {
                var _new = new Unmanaged();
                var _this = AsUnmanaged();
                InteropHelper.interoptopus_string_clone(ref _this, ref _new);
                return _new.IntoManaged();
            }

            [MethodImpl(MethodImplOptions.AggressiveOptimization)]
            public Unmanaged IntoUnmanaged()
            {
                if (_ptr == IntPtr.Zero) { throw new Exception(); }
                var _unmanaged = new Unmanaged();
                _unmanaged._ptr = _ptr;
                _unmanaged._len = _len;
                _unmanaged._capacity = _capacity;
                _ptr = IntPtr.Zero;
                return _unmanaged;
            }

            [MethodImpl(MethodImplOptions.AggressiveOptimization)]
            public Unmanaged AsUnmanaged()
            {
                var _unmanaged = new Unmanaged();
                _unmanaged._ptr = _ptr;
                _unmanaged._len = _len;
                _unmanaged._capacity = _capacity;
                return _unmanaged;
            }

            [StructLayout(LayoutKind.Sequential)]
            public unsafe struct Unmanaged
            {
                public IntPtr _ptr;
                public ulong _len;
                public ulong _capacity;

                [MethodImpl(MethodImplOptions.AggressiveOptimization)]
                public Utf8String IntoManaged()
                {
                    var _managed = new Utf8String();
                    _managed._ptr = _ptr;
                    _managed._len = _len;
                    _managed._capacity = _capacity;
                    return _managed;
                }

            }

            public partial class InteropHelper
            {
                [LibraryImport(Interop.NativeLib, EntryPoint = "interoptopus_string_create")]
                [MethodImpl(MethodImplOptions.AggressiveOptimization)]
                public static partial long interoptopus_string_create(IntPtr utf8, ulong len, out Unmanaged rval);

                [LibraryImport(Interop.NativeLib, EntryPoint = "interoptopus_string_destroy")]
                [MethodImpl(MethodImplOptions.AggressiveOptimization)]
                public static partial long interoptopus_string_destroy(Unmanaged utf8);

                [LibraryImport(Interop.NativeLib, EntryPoint = "interoptopus_string_clone")]
                [MethodImpl(MethodImplOptions.AggressiveOptimization)]
                public static partial long interoptopus_string_clone(ref Unmanaged orig, ref Unmanaged cloned);
            }

            [CustomMarshaller(typeof(Utf8String), MarshalMode.Default, typeof(Marshaller))]
            private struct MarshallerMeta { }

            public ref struct Marshaller
            {
                private Utf8String _managed; // Used when converting managed -> unmanaged
                private Unmanaged _unmanaged; // Used when converting unmanaged -> managed

                [MethodImpl(MethodImplOptions.AggressiveOptimization)]
                public Marshaller(Utf8String managed) { _managed = managed; }
                [MethodImpl(MethodImplOptions.AggressiveOptimization)]
                public Marshaller(Unmanaged unmanaged) { _unmanaged = unmanaged; }

                [MethodImpl(MethodImplOptions.AggressiveOptimization)]
                public void FromManaged(Utf8String managed) { _managed = managed; }
                [MethodImpl(MethodImplOptions.AggressiveOptimization)]
                public void FromUnmanaged(Unmanaged unmanaged) { _unmanaged = unmanaged; }

                [MethodImpl(MethodImplOptions.AggressiveOptimization)]
                public unsafe Unmanaged ToUnmanaged()
                {
                    return _managed.IntoUnmanaged();
                }

                [MethodImpl(MethodImplOptions.AggressiveOptimization)]
                public unsafe Utf8String ToManaged()
                {
                    return _unmanaged.IntoManaged();
                }

                [MethodImpl(MethodImplOptions.AggressiveOptimization)]
                public void Free() { }
            }
        }

        public static class StringExtensions
        {
            public static Utf8String Utf8(this string s) { return Utf8String.From(s); }
        }

}
