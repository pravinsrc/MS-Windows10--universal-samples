//*********************************************************
//
// Copyright (c) Microsoft. All rights reserved.
// This code is licensed under the MIT License (MIT).
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//*********************************************************

#include "pch.h"
#include "Scenario2_UniformSpacing.xaml.h"

using namespace SDKTemplate;
using namespace DWriteTextLayoutImplementation;

using namespace Platform;
using namespace Windows::Foundation;
using namespace Windows::Foundation::Collections;
using namespace Windows::UI::Xaml;
using namespace Windows::UI::Xaml::Controls;
using namespace Windows::UI::Xaml::Controls::Primitives;
using namespace Windows::UI::Xaml::Data;
using namespace Windows::UI::Xaml::Input;
using namespace Windows::UI::Xaml::Media;
using namespace Windows::UI::Xaml::Navigation;


Scenario2_UniformSpacing::Scenario2_UniformSpacing()
{
    InitializeComponent();

    String^ text =
        L"Lorem ipsum dolor sit amet, consectetur 😐 adipiscing elit, sed do eiusmod tempor "
        L"incididunt ut labore et dolore magna aliqua.";

    // Create the TextLayout for our text content.
    m_textLayout = ref new TextLayout(
        text,
        L"en-US",
        L"Cambria Math",
        24.0f, // text size (DIPs)
        static_cast<uint32>(floor(TextLayoutImage->ActualWidth)), // text layout width
        LineSpacingMethod::Uniform
        );

    // Get the array of computed line metrics for the text layout -- we'll 
    // report results for the first line.
    m_textLayoutLineMetrics = m_textLayout->GetTextLayoutLineMetrics();

    // Create a new TextLayoutImageSource based on the text layout, have 
    // it draw, and then use it as the source for the XAML image element.
    m_textLayoutImageSource = ref new TextLayoutImageSource(
        m_textLayout,
        static_cast<uint32>(floor(TextLayoutImage->ActualWidth)),
        static_cast<uint32>(floor(TextLayoutImage->ActualHeight))
        );
    m_textLayoutImageSource->Draw();
    TextLayoutImage->Source = m_textLayoutImageSource;
}


void Scenario2_UniformSpacing::LineSpacingHeight::set(double value)
{
    m_textLayout->LineSpacingHeight = static_cast<float>(value);
    m_textLayoutLineMetrics = m_textLayout->GetTextLayoutLineMetrics();
    m_textLayoutImageSource->Draw();
    this->Bindings->Update();
}


void Scenario2_UniformSpacing::LineSpacingBaseline::set(double value)
{
    m_textLayout->LineSpacingBaseline = static_cast<float>(value);
    m_textLayoutLineMetrics = m_textLayout->GetTextLayoutLineMetrics();
    m_textLayoutImageSource->Draw();
    this->Bindings->Update();
}

