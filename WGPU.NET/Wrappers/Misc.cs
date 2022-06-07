﻿using System;
using System.Text;
using static WGPU.NET.Wgpu;

namespace WGPU.NET
{
    public class ComputePipeline
    {
        internal ComputePipelineImpl Impl;

        internal ComputePipeline(ComputePipelineImpl impl)
        {
            Impl = impl;
        }

        public BindGroupLayout GetBindGroupLayout(uint groupIndex)
            => BindGroupLayout.For(ComputePipelineGetBindGroupLayout(Impl, groupIndex));

        public void SetLabel(string label) => ComputePipelineSetLabel(Impl, label);
    }

    public class PipelineLayout
    {
        internal PipelineLayoutImpl Impl;

        internal PipelineLayout(PipelineLayoutImpl impl)
        {
            Impl = impl;
        }
    }

    public class QuerySet
    {
        private QuerySetImpl _impl;

        internal QuerySet(QuerySetImpl impl)
        {
            Impl = impl;
        }

        internal QuerySetImpl Impl 
        {
            get
            {
                if (_impl.Handle == IntPtr.Zero)
                    throw new HandleDestroyedException(nameof(QuerySet));

                return _impl;
            }

            private set => _impl = value;
        }

        public void DestroyHandle()
        {
            QuerySetDestroy(Impl);
            Impl = default;
        }
    }

    public class RenderPipeline
    {
        internal RenderPipelineImpl Impl;

        internal RenderPipeline(RenderPipelineImpl impl)
        {
            Impl = impl;
        }

        public BindGroupLayout GetBindGroupLayout(uint groupIndex)
            => BindGroupLayout.For(RenderPipelineGetBindGroupLayout(Impl, groupIndex));

        public void SetLabel(string label) => RenderPipelineSetLabel(Impl, label);
    }

    public class Sampler
    {
        internal SamplerImpl Impl;

        internal Sampler(SamplerImpl impl)
        {
            Impl = impl;
        }
    }

    public class ShaderModule
    {
        internal ShaderModuleImpl Impl;

        internal ShaderModule(ShaderModuleImpl impl)
        {
            Impl = impl;
        }

        public unsafe void GetCompilationInfo(CompilationInfoCallback callback)
        {
            ShaderModuleGetCompilationInfo(Impl,
                (CompilationInfoRequestStatus s, in Wgpu.CompilationInfo c, IntPtr _) =>
                {
                    callback(s,
                        new ReadOnlySpan<CompilationMessage>((void*)c.messages, (int)c.messages)
                    );

                }, IntPtr.Zero);
        }

        public void SetLabel(string label) => ShaderModuleSetLabel(Impl, label);
    }

    public delegate void CompilationInfoCallback(CompilationInfoRequestStatus status,
        ReadOnlySpan<CompilationMessage> messages);

    public class SwapChain
    {
        

        internal SwapChainImpl Impl;

        internal SwapChain(SwapChainImpl impl)
        {
            Impl = impl;
        }

        public TextureView GetCurrentTextureView()
            => TextureView.For(SwapChainGetCurrentTextureView(Impl));

        public void Present()
            => SwapChainPresent(Impl);
    }

    public delegate void QueueWorkDoneCallback(QueueWorkDoneStatus status); 

    public class CommandBuffer
    {
        internal CommandBufferImpl Impl;

        internal CommandBuffer(CommandBufferImpl impl)
        {
            Impl = impl;
        }
    }

    public class RenderBundle
    {
        internal RenderBundleImpl Impl;

        internal RenderBundle(RenderBundleImpl impl)
        {
            Impl = impl;
        }
    }
}
