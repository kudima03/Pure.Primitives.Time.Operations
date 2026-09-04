# Changelog

All notable changes to Pure.Primitives.Time.Operations are documented here.

Format follows [Keep a Changelog](https://keepachangelog.com/en/1.1.0/).

---

## [0.4.0] — 2025-11-23

### Changed

- Package now multi-targets `net7.0`, `net8.0`, `net9.0`, and `net10.0`
  (previously `net9.0` only).

## [0.3.0] — 2025-11-01

### Added

- `AfterCondition.BoolValue`, `BeforeCondition.BoolValue`,
  `EqualCondition.BoolValue`, `NotAfterCondition.BoolValue`,
  `NotBeforeCondition.BoolValue`, and `NotEqualCondition.BoolValue` are now
  public properties instead of explicit `IBool` interface implementations,
  so they can be read without casting to `IBool`.

## [0.2.0] — 2025-11-01

### Changed

- **Breaking:** `AfterCondition`, `BeforeCondition`, `EqualCondition`,
  `NotAfterCondition`, `NotBeforeCondition`, and `NotEqualCondition` now
  expose a single `params IEnumerable<ITime>` constructor; the separate
  `params ITime[]` and `IEnumerable<ITime>` overloads were removed.
- Package now declares `IsAotCompatible` for trimming/Native AOT
  compatibility.

## [0.1.0] — 2025-06-18

Initial release.

### Added

- **`EqualCondition`** — `IBool` condition that is `true` when all given
  `ITime` values represent the same time of day.
- **`NotEqualCondition`** — `IBool` condition that is `true` when the given
  `ITime` values are not all equal.
- **`AfterCondition`** — `IBool` condition that is `true` when each `ITime`
  value is strictly later than the one before it.
- **`BeforeCondition`** — `IBool` condition that is `true` when each `ITime`
  value is strictly earlier than the one before it.
- **`NotAfterCondition`** — `IBool` condition that is `true` when each
  `ITime` value is not later than the one before it.
- **`NotBeforeCondition`** — `IBool` condition that is `true` when each
  `ITime` value is not earlier than the one before it.
