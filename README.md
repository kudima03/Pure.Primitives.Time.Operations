# Pure.Primitives.Time.Operations

Temporal comparison conditions and ordering utilities for **Pure** `ITime` primitives.

[![.NET build & test](https://github.com/kudima03/Pure.Primitives.Time.Operations/actions/workflows/build-and-test.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.Primitives.Time.Operations/actions/workflows/build-and-test.yml)
[![Build and Deploy](https://github.com/kudima03/Pure.Primitives.Time.Operations/actions/workflows/publish-nuget.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.Primitives.Time.Operations/actions/workflows/publish-nuget.yml)
[![NuGet](https://img.shields.io/nuget/v/Pure.Primitives.Time.Operations)](https://www.nuget.org/packages/Pure.Primitives.Time.Operations)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

## Overview

`Pure.Primitives.Time.Operations` provides six condition types that evaluate temporal relationships between `ITime` values, plus a `TimeComparer` for ordering. Every condition implements `IBool`, so results compose naturally with other Pure primitives.

## Types

| Type | True when |
|------|-----------|
| `EqualCondition` | All supplied `ITime` values represent the same time-of-day |
| `NotEqualCondition` | Not all values represent the same time-of-day |
| `BeforeCondition` | Each value in the sequence is strictly earlier than the previous |
| `AfterCondition` | Each value in the sequence is strictly later than the previous |
| `NotBeforeCondition` | The sequence is not strictly descending |
| `NotAfterCondition` | The sequence is not strictly ascending |
| `TimeComparer` | `IComparer<ITime>` for ordering time values |

All condition types accept `params IEnumerable<ITime>` and implement `IBool`. Comparison covers hour, minute, second, millisecond, microsecond, and nanosecond fields.

## Dependencies

- [`Pure.Primitives.Abstractions`](https://github.com/kudima03/Pure.Primitives.Abstractions) — `ITime` and `IBool` interfaces
